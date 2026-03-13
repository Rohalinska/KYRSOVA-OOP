using System;

namespace LibrarySystem.Core.Models
{
    public class HistoryRecord
    {
        public string BookTitle { get; set; }
        public string ReaderName { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal FineAmount { get; set; }
    }
}