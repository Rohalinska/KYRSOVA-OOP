using LibrarySystem.Core.Patterns.State;
using LibrarySystem.Core.Patterns.Strategy;

namespace LibrarySystem.Core.Models
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public IFineStrategy FineStrategy { get; set; }
        public IBookState State { get; set; }

        public Book(string id, string title, string author, IFineStrategy fineStrategy)
        {
            Id = id;
            Title = title;
            Author = author;
            FineStrategy = fineStrategy;
            State = new AvailableState(); 
        }

        public void Borrow() => State.Borrow(this);
        public void ReturnBook() => State.ReturnBook(this);
    }
}