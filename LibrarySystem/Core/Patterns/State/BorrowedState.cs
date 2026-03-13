using LibrarySystem.Core.Exceptions;
using LibrarySystem.Core.Models;

namespace LibrarySystem.Core.Patterns.State
{
    public class BorrowedState : IBookState
    {
        public string StateName => "Borrowed";

        public void Borrow(Book book)
        {
            throw new LibraryException("Книга вже видана іншому читачу.");
        }

        public void ReturnBook(Book book)
        {
            book.State = new AvailableState();
        }
    }
}