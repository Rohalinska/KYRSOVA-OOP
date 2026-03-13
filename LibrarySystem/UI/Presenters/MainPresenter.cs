using System;
using System.Linq;
using LibrarySystem.Core.Exceptions;
using LibrarySystem.Core.Facade;
using LibrarySystem.Core.Patterns.Factory;
using LibrarySystem.UI.Views;

namespace LibrarySystem.UI.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly LibraryManager _libraryManager;

        public MainPresenter(IMainView view, LibraryManager libraryManager)
        {
            _view = view;
            _libraryManager = libraryManager;

            _view.AddBookClicked += OnAddBook;
            _view.AddReaderClicked += OnAddReader;
            _view.BorrowBookClicked += OnBorrowBook;
            _view.ReturnBookClicked += OnReturnBook;

            _libraryManager.OnLibraryUpdated += (message) =>
            {
                _view.AppendLog(message);
                RefreshUI();
            };

            RefreshUI(); 
        }

        private void OnAddBook(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_view.BookTitleInput) || string.IsNullOrWhiteSpace(_view.BookAuthorInput))
                    throw new LibraryException("Заповніть назву та автора!");

                var book = BookFactory.CreateBook(_view.BookTitleInput, _view.BookAuthorInput, _view.BookTypeInput);
                _libraryManager.AddBook(book);

                _view.BookTitleInput = "";
                _view.BookAuthorInput = "";
            }
            catch (Exception ex) { _view.ShowMessage(ex.Message, true); }
        }

        private void OnAddReader(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_view.ReaderNameInput))
                    throw new LibraryException("Введіть ПІБ читача!");

                var reader = ReaderFactory.CreateReader(_view.ReaderNameInput);
                _libraryManager.AddReader(reader);

                _view.ReaderNameInput = "";
            }
            catch (Exception ex) { _view.ShowMessage(ex.Message, true); }
        }

        private void OnBorrowBook(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_view.SelectedReaderIdToBorrow) || string.IsNullOrEmpty(_view.SelectedBookIdToBorrow))
                    throw new LibraryException("Оберіть читача та книгу!");

                _libraryManager.BorrowBook(_view.SelectedReaderIdToBorrow, _view.SelectedBookIdToBorrow, _view.LoanDaysInput);
            }
            catch (Exception ex) { _view.ShowMessage(ex.Message, true); }
        }

        private void OnReturnBook(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_view.SelectedBookIdToReturn))
                    throw new LibraryException("Оберіть книгу для повернення!");

                var fine = _libraryManager.ReturnBook(_view.SelectedBookIdToReturn);
                if (fine > 0)
                    _view.ShowMessage($"Книгу повернуто із простроченням.\nНараховано штраф: {fine} грн.", true);
                else
                    _view.ShowMessage("Книгу повернуто вчасно. Штрафів немає.", false);
            }
            catch (Exception ex) { _view.ShowMessage(ex.Message, true); }
        }

        private void RefreshUI()
        {
            var booksData = _libraryManager.Books.Select(b => new {
                ID = b.Id,
                Назва = b.Title,
                Автор = b.Author,
                Тип = b.FineStrategy.StrategyName,
                Статус = b.State.StateName
            }).ToList();

            var readersData = _libraryManager.Readers.Select(r => new {
                ID = r.Id,
                ПІБ = r.Name,
                Книг_на_руках = _libraryManager.ActiveLoans.Count(l => l.Reader.Id == r.Id)
            }).ToList();

            var historyData = _libraryManager.History.Select(h => new {
                Книга = h.BookTitle,
                Читач = h.ReaderName,
                Видано = h.IssueDate.ToShortDateString(),
                Повернуто = h.ReturnDate.ToShortDateString(),
                Штраф = h.FineAmount + " грн"
            }).ToList();

            var availableBooks = _libraryManager.Books.Where(b => b.State.StateName == "Available")
                .Select(b => new { Id = b.Id, Display = $"{b.Title}[{b.Id}]" }).ToList();

            var allReaders = _libraryManager.Readers
                .Select(r => new { Id = r.Id, Display = $"{r.Name} [{r.Id}]" }).ToList();

            var activeLoans = _libraryManager.ActiveLoans
                .Select(l => new { Id = l.Book.Id, Display = $"{l.Book.Title} (у: {l.Reader.Name})" }).ToList();

            _view.UpdateBooksList(booksData);
            _view.UpdateReadersList(readersData);
            _view.UpdateHistoryList(historyData);
            _view.UpdateDropdowns(availableBooks, allReaders, activeLoans);
        }
    }
}