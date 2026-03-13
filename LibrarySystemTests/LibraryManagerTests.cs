using System;
using System.Linq;
using Xunit;
using LibrarySystem.Core.Exceptions;
using LibrarySystem.Core.Facade;
using LibrarySystem.Core.Patterns.Factory;

namespace LibrarySystem.Tests
{
    public class LibraryManagerTests
    {
        private readonly LibraryManager _manager;

        public LibraryManagerTests()
        {
            var fakeRepo = new FakeLibraryRepository();
            _manager = new LibraryManager(fakeRepo);

            // Виправив імена та назви
            var reader = ReaderFactory.CreateReader("Тестовий Читач", "R-1");
            _manager.AddReader(reader);

            var standardBook = BookFactory.CreateBook("Стандартна Книга", "Автор 1", "Standard", "B-1");
            var rareBook = BookFactory.CreateBook("Рідкісна Книга", "Автор 2", "Rare", "B-2");

            _manager.AddBook(standardBook);
            _manager.AddBook(rareBook);
        }

        [Fact]
        public void BorrowBook_Successful_CreatesLoanAndChangesState()
        {
            _manager.BorrowBook("R-1", "B-1", 14);

            Assert.Single(_manager.ActiveLoans);
            var book = _manager.Books.First(b => b.Id == "B-1");
            Assert.Equal("Borrowed", book.State.StateName); 
        }

        [Fact]
        public void BorrowBook_AlreadyBorrowed_ThrowsException()
        {
            _manager.BorrowBook("R-1", "B-1", 14);

            var ex = Assert.Throws<LibraryException>(() => _manager.BorrowBook("R-1", "B-1", 14));
            
            // ТУТ БУЛА ПОМИЛКА: Замінив знаки питання на правильний текст з вашого консольного виводу
            Assert.Equal("Книга вже видана іншому читачу.", ex.Message);
        }

        [Fact]
        public void ReturnBook_OnTime_NoFine()
        {
            var today = DateTime.Now;
            _manager.BorrowBook("R-1", "B-1", 14, today);

            var returnDate = today.AddDays(10);
            var fine = _manager.ReturnBook("B-1", returnDate);

            Assert.Equal(0m, fine);
            Assert.Empty(_manager.ActiveLoans);
        }

        [Fact]
        public void ReturnBook_LateStandardBook_CalculatesStandardFine()
        {
            var today = DateTime.Now;
            _manager.BorrowBook("R-1", "B-1", 14, today);

            // Протермінування на 2 дні (16 - 14 = 2)
            var returnDate = today.AddDays(16); 
            var fine = _manager.ReturnBook("B-1", returnDate);

            // Здається, ваш стандартний штраф = 10 за день (2 дні * 10 = 20)
            Assert.Equal(20m, fine);
        }

        [Fact]
        public void ReturnBook_LateRareBook_CalculatesRareFine()
        {
            var today = DateTime.Now;
            _manager.BorrowBook("R-1", "B-2", 14, today);

            // Протермінування на 2 дні (16 - 14 = 2)
            var returnDate = today.AddDays(16); 
            var fine = _manager.ReturnBook("B-2", returnDate);

            // Якщо очікується 100, значить штраф за Rare книгу має бути 50 за день (2 дні * 50 = 100)
            Assert.Equal(100m, fine);
        }

        [Fact]
        public void ReturnBook_AddsRecordToHistory()
        {
            var today = DateTime.Now;
            _manager.BorrowBook("R-1", "B-1", 14, today);

            _manager.ReturnBook("B-1", today.AddDays(10));

            Assert.Single(_manager.History);
            var historyRecord = _manager.History.First();
            
            // Виправив очікувані значення, щоб вони збігалися з тим, що ми створили вище
            Assert.Equal("Стандартна Книга", historyRecord.BookTitle);
            Assert.Equal("Тестовий Читач", historyRecord.ReaderName);
            Assert.Equal(0m, historyRecord.FineAmount);
        }
    }
}