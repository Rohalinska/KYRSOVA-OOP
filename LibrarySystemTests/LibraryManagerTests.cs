using Xunit;
using LibrarySystem.Core.Models;
using LibrarySystem.Core.Facade;

namespace LibrarySystemTests
{
    public class LibraryManagerTests
    {
        //№1
        [Fact]
        public void AddBook_ShouldAddBook()
        {
            var repo = new FakeLibraryRepository();
            var manager = new LibraryManager(repo);

            var book = new Book("1", "TestBook", "Author", null);

            manager.AddBook(book);

            Assert.Single(repo.GetAllBooks());
        }
        //№2
        [Fact]
        public void AddReader_ShouldAddReader()
        {
            var repo = new FakeLibraryRepository();
            var manager = new LibraryManager(repo);

            var reader = new Reader("1", "TestReader");

            manager.AddReader(reader);

            Assert.Single(repo.GetAllReaders());
        }
        //№3
        [Fact]
        public void BorrowBook_ShouldCreateLoan()
        {
            var repo = new FakeLibraryRepository();
            var manager = new LibraryManager(repo);

            var book = new Book("1", "Book1", "Author1", null);
            var reader = new Reader("1", "Reader1");

            manager.AddBook(book);
            manager.AddReader(reader);

            manager.BorrowBook("1", "1");

            Assert.Single(repo.GetAllLoans(null, null));
        }
        //№4
        [Fact]
        public void ReturnBook_ShouldRemoveLoan()
        {
            var repo = new FakeLibraryRepository();
            var manager = new LibraryManager(repo);

            var book = new Book("1", "Book1", "Author1", null);
            var reader = new Reader("1", "Reader1");

            manager.AddBook(book);
            manager.AddReader(reader);

            manager.BorrowBook("1", "1");
            manager.ReturnBook("1");

            Assert.Empty(repo.GetAllLoans(null, null));
        }
        //№5: Перевірка, чи додається запис в історію після повернення книги
        [Fact]
        public void ReturnBook_ShouldAddRecordToHistory()
        {
            var repo = new FakeLibraryRepository();
            var manager = new LibraryManager(repo);

            var book = new Book("1", "Book1", "Author1", null);
            var reader = new Reader("1", "Reader1");

            manager.AddBook(book);
            manager.AddReader(reader);
            
            manager.BorrowBook("1", "1");
            manager.ReturnBook("1");

            // Перевіряємо, що після повернення створено запис в історії
            Assert.Single(repo.GetHistory());
        }

        //№6: Спроба взяти книгу, якої не існує в бібліотеці (має викинути помилку)
        [Fact]
        public void BorrowBook_WhenBookDoesNotExist_ShouldThrowException()
        {
            var repo = new FakeLibraryRepository();
            var manager = new LibraryManager(repo);
            var reader = new Reader("1", "TestReader");
            manager.AddReader(reader);

            // Очікуємо виключення (Exception) при спробі взяти неіснуючу книгу
            Assert.ThrowsAny<Exception>(() => manager.BorrowBook("999", "1"));
        }

        //№7: Спроба взяти книгу неіснуючим читачем (має викинути помилку)
        [Fact]
        public void BorrowBook_WhenReaderDoesNotExist_ShouldThrowException()
        {
            var repo = new FakeLibraryRepository();
            var manager = new LibraryManager(repo);
            var book = new Book("1", "TestBook", "Author", null);
            manager.AddBook(book);

            // Очікуємо виключення при спробі видати книгу неіснуючому читачу
            Assert.ThrowsAny<Exception>(() => manager.BorrowBook("1", "999"));
        }

        //№8: Спроба взяти книгу, яка вже видана іншому читачу
        [Fact]
        public void BorrowBook_WhenBookAlreadyBorrowed_ShouldThrowException()
        {
            var repo = new FakeLibraryRepository();
            var manager = new LibraryManager(repo);

            var book = new Book("1", "TestBook", "Author", null);
            var reader1 = new Reader("1", "Reader1");
            var reader2 = new Reader("2", "Reader2");

            manager.AddBook(book);
            manager.AddReader(reader1);
            manager.AddReader(reader2);

            // Перший читач бере книгу
            manager.BorrowBook("1", "1");

            // Другий читач намагається взяти ту саму книгу
            Assert.ThrowsAny<Exception>(() => manager.BorrowBook("1", "2"));
        }
        //№9: Спроба повернути книгу, яка не була видана
        [Fact]
        public void ReturnBook_WhenBookNotBorrowed_ShouldNotChangeState()
        {
            var repo = new FakeLibraryRepository();
            var manager = new LibraryManager(repo);

            var book = new Book("1", "TestBook", "Author", null);
            manager.AddBook(book);

            // Просто викликаємо метод (помилки не буде)
            manager.ReturnBook("1");

            // Перевіряємо, що історія залишилась порожньою, бо реально нічого не повертали
            Assert.Empty(repo.GetHistory());
        }

         //№10: Комплексна перевірка стану (кілька операцій підряд)
        [Fact]
        public void MultipleOperations_ShouldMaintainCorrectState()
        {
            var repo = new FakeLibraryRepository();
            var manager = new LibraryManager(repo);

            manager.AddBook(new Book("1", "Book1", "Author1", null));
            manager.AddBook(new Book("2", "Book2", "Author2", null));
            manager.AddReader(new Reader("1", "Reader1"));

            // Читач "1" бере книгу "1"
            manager.BorrowBook("1", "1"); 
            // Читач "1" бере книгу "2" (тут була помилка з порядком)
            manager.BorrowBook("1", "2"); 
            
            // Повертаємо книгу "1" (залежить від того, як працює твій ReturnBook, 
            // якщо він приймає ID книги, то залишаємо так)
            manager.ReturnBook("1");

            // Перевіряємо залишковий стан системи
            Assert.Single(repo.GetAllLoans(null, null)); // В оренді залишилась 1 книга
            Assert.Single(repo.GetHistory());            // В історії 1 запис про повернення
        }
    }
}