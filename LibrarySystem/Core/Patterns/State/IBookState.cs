using LibrarySystem.Core.Models;

namespace LibrarySystem.Core.Patterns.State
{
    public interface IBookState
    {
        void Borrow(Book book);
        void ReturnBook(Book book);
        string StateName { get; } 
    }
}