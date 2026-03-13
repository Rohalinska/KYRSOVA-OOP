using System.Collections.Generic;
using LibrarySystem.Core.Models;

namespace LibrarySystem.Core.Interfaces
{
    public interface ILibraryRepository
    {
        void SaveBook(Book book);
        void SaveReader(Reader reader);
        void SaveLoan(Loan loan);
        void DeleteLoan(string bookId);
        void ArchiveLoan(HistoryRecord record);

        IEnumerable<Book> GetAllBooks();
        IEnumerable<Reader> GetAllReaders();
        IEnumerable<Loan> GetAllLoans(IEnumerable<Book> books, IEnumerable<Reader> readers);
        IEnumerable<HistoryRecord> GetHistory();
    }
}