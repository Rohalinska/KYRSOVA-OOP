// =======================
    // Пошук
    // =======================
    class SearchService
    {
        public static void SearchByTitle(List<Book> books, string title)
        {
            var result = books.Where(b => b.Title.Contains(title));
            foreach (var book in result)
                Console.WriteLine($"{book.Title} - {book.Author}");
        }

        public static void SearchByAuthor(List<Book> books, string author)
        {
            var result = books.Where(b => b.Author.Contains(author));
            foreach (var book in result)
                Console.WriteLine($"{book.Title} - {book.Author}");
        }
    }

    // =======================
    // MAIN
    // =======================
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseConnection db = DatabaseConnection.GetInstance();

            List<Book> books = new List<Book>
            {
                new Book(1, "1984", "Орвелл", 2),
                new Book(2, "Кобзар", "Шевченко", 1)
            };

            ReaderFactory factory = new ReaderFactory();
            Reader reader = (Reader)factory.CreateUser("Олександра");

            LoanHistory history = new LoanHistory();

            Book selectedBook = books[0];

            if (selectedBook.IsAvailable())
            {
                selectedBook.DecreaseCopies();

                IFineStrategy strategy = new DailyFineStrategy();
                Loan loan = new Loan(selectedBook, reader, strategy);

                history.AddLoan(loan);

                Console.WriteLine("Книга видана!");

                double fine = loan.ReturnBook();
                Console.WriteLine($"Штраф: {fine} грн");
            }

            Console.WriteLine("\nПошук книги по назві:");
            SearchService.SearchByTitle(books, "1984");

            Console.WriteLine("\nІсторія читача:");
            history.ShowReaderHistory("Олександра");

            Console.ReadLine();
        }
    }
}