using System;

namespace LibrarySystem.Core.Models
{
    public class Loan
    {
        public Book Book { get; set; }
        public Reader Reader { get; set; }
        public DateTime IssueDate { get; set; }
        public int MaxLoanDays { get; set; }

        public Loan(Book book, Reader reader, DateTime issueDate, int maxLoanDays)
        {
            Book = book;
            Reader = reader;
            IssueDate = issueDate;
            MaxLoanDays = maxLoanDays;
        }

        public int GetOverdueDays(DateTime returnDate)
        {
            var delta = returnDate - IssueDate;
            int overdue = delta.Days - MaxLoanDays;
            return Math.Max(0, overdue);
        }
    }
}