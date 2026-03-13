using System;

namespace LibrarySystem.Core.Exceptions
{
    public class LibraryException : Exception
    {
        public LibraryException(string message) : base(message) { }
    }
}