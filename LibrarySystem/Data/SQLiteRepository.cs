using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;
using LibrarySystem.Core.Patterns.State;
using LibrarySystem.Core.Patterns.Strategy;

namespace LibrarySystem.Data
{
    public class SQLiteRepository : ILibraryRepository
    {
        private readonly string _connectionString;

        public SQLiteRepository(string dbPath = "library.db")
        {
            _connectionString = $"Data Source={dbPath}";
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Books (
                    Id TEXT PRIMARY KEY,
                    Title TEXT NOT NULL,
                    Author TEXT NOT NULL,
                    FineType TEXT NOT NULL,
                    State TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Readers (
                    Id TEXT PRIMARY KEY,
                    Name TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Loans (
                    BookId TEXT PRIMARY KEY,
                    ReaderId TEXT NOT NULL,
                    IssueDate TEXT NOT NULL,
                    MaxLoanDays INTEGER NOT NULL
                );

                CREATE TABLE IF NOT EXISTS History (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    BookTitle TEXT NOT NULL,
                    ReaderName TEXT NOT NULL,
                    IssueDate TEXT NOT NULL,
                    ReturnDate TEXT NOT NULL,
                    FineAmount REAL NOT NULL
                );
            ";
            command.ExecuteNonQuery();
        }

        public void SaveBook(Book book)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT OR REPLACE INTO Books (Id, Title, Author, FineType, State)
                VALUES ($id, $title, $author, $fineType, $state)";

            command.Parameters.AddWithValue("$id", book.Id);
            command.Parameters.AddWithValue("$title", book.Title);
            command.Parameters.AddWithValue("$author", book.Author);
            command.Parameters.AddWithValue("$fineType", book.FineStrategy.StrategyName);
            command.Parameters.AddWithValue("$state", book.State.StateName);

            command.ExecuteNonQuery();
        }

        public void SaveReader(Reader reader)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT OR REPLACE INTO Readers (Id, Name) VALUES ($id, $name)";
            command.Parameters.AddWithValue("$id", reader.Id);
            command.Parameters.AddWithValue("$name", reader.Name);

            command.ExecuteNonQuery();
        }

        public void SaveLoan(Loan loan)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT OR REPLACE INTO Loans (BookId, ReaderId, IssueDate, MaxLoanDays)
                VALUES ($bookId, $readerId, $issueDate, $maxDays)";

            command.Parameters.AddWithValue("$bookId", loan.Book.Id);
            command.Parameters.AddWithValue("$readerId", loan.Reader.Id);
            command.Parameters.AddWithValue("$issueDate", loan.IssueDate.ToString("O")); 
            command.Parameters.AddWithValue("$maxDays", loan.MaxLoanDays);

            command.ExecuteNonQuery();
        }

        public void DeleteLoan(string bookId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Loans WHERE BookId = $bookId";
            command.Parameters.AddWithValue("$bookId", bookId);

            command.ExecuteNonQuery();
        }

        public void ArchiveLoan(HistoryRecord record)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO History (BookTitle, ReaderName, IssueDate, ReturnDate, FineAmount)
                VALUES ($book, $reader, $issue, $return, $fine)";

            command.Parameters.AddWithValue("$book", record.BookTitle);
            command.Parameters.AddWithValue("$reader", record.ReaderName);
            command.Parameters.AddWithValue("$issue", record.IssueDate.ToString("O"));
            command.Parameters.AddWithValue("$return", record.ReturnDate.ToString("O"));
            command.Parameters.AddWithValue("$fine", record.FineAmount);

            command.ExecuteNonQuery();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var books = new List<Book>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Title, Author, FineType, State FROM Books";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var id = reader.GetString(0);
                var title = reader.GetString(1);
                var author = reader.GetString(2);
                var fineType = reader.GetString(3);
                var stateName = reader.GetString(4);

                IFineStrategy strategy = fineType == "Rare" ? new RareBookFineStrategy() : new StandardFineStrategy();

                var book = new Book(id, title, author, strategy);

                if (stateName == "Borrowed")
                    book.State = new BorrowedState();

                books.Add(book);
            }

            return books;
        }

        public IEnumerable<Reader> GetAllReaders()
        {
            var readers = new List<Reader>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Name FROM Readers";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                readers.Add(new Reader(reader.GetString(0), reader.GetString(1)));
            }

            return readers;
        }

        public IEnumerable<Loan> GetAllLoans(IEnumerable<Book> books, IEnumerable<Reader> readers)
        {
            var loans = new List<Loan>();
            var bookList = books.ToList();
            var readerList = readers.ToList();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT BookId, ReaderId, IssueDate, MaxLoanDays FROM Loans";

            using var dbReader = command.ExecuteReader();
            while (dbReader.Read())
            {
                var bookId = dbReader.GetString(0);
                var readerId = dbReader.GetString(1);
                var issueDate = DateTime.Parse(dbReader.GetString(2));
                var maxDays = dbReader.GetInt32(3);

                var book = bookList.FirstOrDefault(b => b.Id == bookId);
                var reader = readerList.FirstOrDefault(r => r.Id == readerId);

                if (book != null && reader != null)
                {
                    loans.Add(new Loan(book, reader, issueDate, maxDays));
                }
            }

            return loans;
        }

        public IEnumerable<HistoryRecord> GetHistory()
        {
            var history = new List<HistoryRecord>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT BookTitle, ReaderName, IssueDate, ReturnDate, FineAmount FROM History ORDER BY Id DESC";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                history.Add(new HistoryRecord
                {
                    BookTitle = reader.GetString(0),
                    ReaderName = reader.GetString(1),
                    IssueDate = DateTime.Parse(reader.GetString(2)),
                    ReturnDate = DateTime.Parse(reader.GetString(3)),
                    FineAmount = reader.GetDecimal(4)
                });
            }

            return history;
        }
    }
}