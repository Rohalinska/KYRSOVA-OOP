using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace LibrarySystem.Tests
{
    public class FakeLibraryRepository : ILibraryRepository
    {
        private readonly List<Book> _books = new();
        private readonly List<Reader> _readers = new();
        private readonly List<Loan> _loans = new();
        private readonly List<HistoryRecord> _history = new();

        public void SaveBook(Book book)
        {
            _books.RemoveAll(b => b.Id == book.Id);
            _books.Add(book);
        }

        public void SaveReader(Reader reader)
        {
            _readers.RemoveAll(r => r.Id == reader.Id);
            _readers.Add(reader);
        }

        public void SaveLoan(Loan loan)
        {
            _loans.RemoveAll(l => l.Book.Id == loan.Book.Id);
            _loans.Add(loan);
        }

        public void DeleteLoan(string bookId)
        {
            _loans.RemoveAll(l => l.Book.Id == bookId);
        }

        public void ArchiveLoan(HistoryRecord record)
        {
            _history.Add(record);
        }

        public IEnumerable<Book> GetAllBooks() => _books;
        public IEnumerable<Reader> GetAllReaders() => _readers;
        public IEnumerable<Loan> GetAllLoans(IEnumerable<Book> books, IEnumerable<Reader> readers) => _loans;
        public IEnumerable<HistoryRecord> GetHistory() => _history;
    }
}