using System;
using System.Collections.Generic;

namespace LibrarySystem.UI.Views
{
    public interface IMainView
    {
        string BookTitleInput { get; set; }
        string BookAuthorInput { get; set; }
        string BookTypeInput { get; set; }
        string ReaderNameInput { get; set; }
        int LoanDaysInput { get; set; }

        string SelectedReaderIdToBorrow { get; }
        string SelectedBookIdToBorrow { get; }
        string SelectedBookIdToReturn { get; }

        public event EventHandler? AddBookClicked;
        public event EventHandler? AddReaderClicked;
        event EventHandler BorrowBookClicked;
        event EventHandler ReturnBookClicked;

        void UpdateBooksList(object booksData);
        void UpdateReadersList(object readersData);
        void UpdateHistoryList(object historyData);
        void UpdateDropdowns(object availableBooks, object allReaders, object activeLoans);

        void AppendLog(string message);
        void ShowMessage(string message, bool isError = false);
    }
}