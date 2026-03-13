using LibrarySystem.Core.Exceptions;
using LibrarySystem.Core.Models;

namespace LibrarySystem.Core.Patterns.State
{
    public class AvailableState : IBookState
    {
        public string StateName => "Available";

        public void Borrow(Book book)
        {
            book.State = new BorrowedState();
        }

        public void ReturnBook(Book book)
        {
            throw new LibraryException("Ця книга вже знаходиться в бібліотеці і доступна.");
        }
    }
}