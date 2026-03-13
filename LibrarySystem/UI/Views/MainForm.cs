using System;
using System.Windows.Forms;

namespace LibrarySystem.UI.Views
{
    public partial class MainForm : Form, IMainView
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void BtnAddBook_Click(object sender, EventArgs e)
        {
            AddBookClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnAddReader_Click(object sender, EventArgs e)
        {
            AddReaderClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnBorrow_Click(object sender, EventArgs e)
        {
            BorrowBookClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            ReturnBookClicked?.Invoke(this, EventArgs.Empty);
        }

        public string BookTitleInput { get => txtBookTitle.Text; set => txtBookTitle.Text = value; }
        public string BookAuthorInput { get => txtBookAuthor.Text; set => txtBookAuthor.Text = value; }
        public string BookTypeInput { get => cmbBookType.SelectedItem?.ToString(); set => cmbBookType.SelectedItem = value; }
        public string ReaderNameInput { get => txtReaderName.Text; set => txtReaderName.Text = value; }
        public int LoanDaysInput { get => (int)numLoanDays.Value; set => numLoanDays.Value = value; }

        public string SelectedReaderIdToBorrow => cmbReaderBorrow.SelectedValue?.ToString();
        public string SelectedBookIdToBorrow => cmbBookBorrow.SelectedValue?.ToString();
        public string SelectedBookIdToReturn => cmbBookReturn.SelectedValue?.ToString();

        public event EventHandler? AddBookClicked;
        public event EventHandler? AddReaderClicked;
        public event EventHandler? BorrowBookClicked;
        public event EventHandler? ReturnBookClicked;

        public void UpdateBooksList(object data) => SafeInvoke(() => gridBooks.DataSource = data);
        public void UpdateReadersList(object data) => SafeInvoke(() => gridReaders.DataSource = data);
        public void UpdateHistoryList(object data) => SafeInvoke(() => gridHistory.DataSource = data);

        public void UpdateDropdowns(object availableBooks, object allReaders, object activeLoans)
        {
            SafeInvoke(() =>
            {
                BindCombo(cmbBookBorrow, availableBooks);
                BindCombo(cmbReaderBorrow, allReaders);
                BindCombo(cmbBookReturn, activeLoans);
            });
        }

        private void BindCombo(ComboBox cb, object data)
        {
            cb.DataSource = null;
            cb.DataSource = data;
            cb.DisplayMember = "Display";
            cb.ValueMember = "Id";
            cb.SelectedIndex = -1;
        }

        public void AppendLog(string message)
        {
            SafeInvoke(() =>
            {
                rtbLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\n");
                rtbLog.ScrollToCaret();
            });
        }

        public void ShowMessage(string msg, bool isError)
        {
            SafeInvoke(() =>
                MessageBox.Show(msg, isError ? "�������" : "����������", MessageBoxButtons.OK, isError ? MessageBoxIcon.Warning : MessageBoxIcon.Information)
            );
        }

        private void SafeInvoke(Action action)
        {
            if (InvokeRequired) Invoke(action);
            else action();
        }

    }
}