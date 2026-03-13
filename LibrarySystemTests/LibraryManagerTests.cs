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

            var reader = ReaderFactory.CreateReader("�������� �����", "R-1");
            _manager.AddReader(reader);

            var standardBook = BookFactory.CreateBook("�������� �����", "����� 1", "����������", "B-1");
            var rareBook = BookFactory.CreateBook("г����� �����", "����� 2", "г�����", "B-2");

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
            Assert.Equal("����� ��� ������ ������ ������.", ex.Message);
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

            var returnDate = today.AddDays(16); 
            var fine = _manager.ReturnBook("B-1", returnDate);

            Assert.Equal(20m, fine);
        }

        [Fact]
        public void ReturnBook_LateRareBook_CalculatesRareFine()
        {
            var today = DateTime.Now;
            _manager.BorrowBook("R-1", "B-2", 14, today);

            var returnDate = today.AddDays(16); 
            var fine = _manager.ReturnBook("B-2", returnDate);

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
            Assert.Equal("�������� �����", historyRecord.BookTitle);
            Assert.Equal("�������� �����", historyRecord.ReaderName);
            Assert.Equal(0m, historyRecord.FineAmount);
        }
    }
}