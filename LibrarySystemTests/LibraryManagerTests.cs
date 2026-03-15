using Xunit;
using LibrarySystem.Core.Models;
using LibrarySystem.Core.Facade;

namespace LibrarySystemTests
{
    public class LibraryManagerTests
    {
        [Fact]
        public void AddBook_ShouldAddBook()
        {
            var repo = new FakeLibraryRepository();
            var manager = new LibraryManager(repo);

            var book = new Book("1", "TestBook", "Author", null);

            manager.AddBook(book);

            Assert.Single(repo.GetAllBooks());
        }

        [Fact]
        public void AddReader_ShouldAddReader()
        {
            var repo = new FakeLibraryRepository();
            var manager = new LibraryManager(repo);

            var reader = new Reader("1", "TestReader");

            manager.AddReader(reader);

            Assert.Single(repo.GetAllReaders());
        }

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
    }
}