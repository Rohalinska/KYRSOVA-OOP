using System.Collections.Generic;
using System.Linq;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;

namespace LibrarySystemTests
{
    public class FakeLibraryRepository : ILibraryRepository
    {
        private List<Book> books = new();
        private List<Reader> readers = new();
        private List<Loan> loans = new();
        private List<HistoryRecord> history = new();

        public void SaveBook(Book book)
        {
            books.Add(book);
        }

        public void SaveReader(Reader reader)
        {
            readers.Add(reader);
        }

        public void SaveLoan(Loan loan)
        {
            loans.Add(loan);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return books;
        }

        public IEnumerable<Reader> GetAllReaders()
        {
            return readers;
        }

        public IEnumerable<Loan> GetAllLoans(IEnumerable<Book> books, IEnumerable<Reader> readers)
        {
            return loans;
        }

        public void DeleteLoan(string id)
        {
            var loan = loans.FirstOrDefault(l => l.Book.Id == id);
            if (loan != null)
                loans.Remove(loan);
        }

        public void ArchiveLoan(HistoryRecord record)
        {
            history.Add(record);
        }

        public IEnumerable<HistoryRecord> GetHistory()
        {
            return history;
        }
    }
}