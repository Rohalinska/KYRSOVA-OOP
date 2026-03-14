using System;
using System.Collections.Generic;
using System.Linq;
using LibrarySystem.Core.Exceptions;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;

namespace LibrarySystem.Core.Facade
{
    public class LibraryManager
    {
        private readonly ILibraryRepository _repository;

        public event Action<string> OnLibraryUpdated;

        public LibraryManager(ILibraryRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IEnumerable<Book> Books => _repository.GetAllBooks();
        public IEnumerable<Reader> Readers => _repository.GetAllReaders();
        public IEnumerable<Loan> ActiveLoans => _repository.GetAllLoans(Books, Readers);
        public IEnumerable<HistoryRecord> History => _repository.GetHistory();

        public void AddBook(Book book)
        {
            if (Books.Any(b => b.Id == book.Id))
                throw new LibraryException("Книга з таким ID вже існує!");

            _repository.SaveBook(book);
            OnLibraryUpdated?.Invoke($"[BOOK_ADDED] Додано книгу: {book.Title}");
        }

        public void AddReader(Reader reader)
        {
            if (Readers.Any(r => r.Id == reader.Id))
                throw new LibraryException("Читач з таким ID вже існує!");

            _repository.SaveReader(reader);
            OnLibraryUpdated?.Invoke($"[READER_ADDED] Додано читача: {reader.Name}");
        }

        public void BorrowBook(string readerId, string bookId, int loanDays = 14, DateTime? currentDate = null)
        {
            var date = currentDate ?? DateTime.Now;

            var book = Books.FirstOrDefault(b => b.Id == bookId) ?? throw new LibraryException("Книгу не знайдено.");
            var reader = Readers.FirstOrDefault(r => r.Id == readerId) ?? throw new LibraryException("Читача не знайдено.");

            book.Borrow(); 

            _repository.SaveBook(book);
            _repository.SaveLoan(new Loan(book, reader, date, loanDays));

            OnLibraryUpdated?.Invoke($"[BOOK_BORROWED] Книгу '{book.Title}' видано читачу '{reader.Name}'.");
        }

public decimal ReturnBook(string bookId, DateTime? returnDate = null)
        {
            var date = returnDate ?? DateTime.Now;

            var loan = ActiveLoans.FirstOrDefault(l => l.Book.Id == bookId)
                ?? throw new LibraryException("Ця книга не числиться як видана.");

            var book = loan.Book;
            book.ReturnBook();

            _repository.DeleteLoan(bookId);
            _repository.SaveBook(book);

            var overdueDays = loan.GetOverdueDays(date);

            // ТЕСТОВИЙ РЯДОК: Штучно робимо 5 днів прострочення
            overdueDays = 5; 

            var fineAmount = book.FineStrategy.CalculateFine(overdueDays);

            _repository.ArchiveLoan(new HistoryRecord
            {
                BookTitle = book.Title,
                ReaderName = loan.Reader.Name,
                IssueDate = loan.IssueDate,
                ReturnDate = date,
                FineAmount = fineAmount
            });

            string msg = $"[BOOK_RETURNED] Книгу '{book.Title}' повернуто.";
            if (fineAmount > 0) msg += $" Штраф: {fineAmount} грн.";

            OnLibraryUpdated?.Invoke(msg);
            return fineAmount;
        }
    }
}