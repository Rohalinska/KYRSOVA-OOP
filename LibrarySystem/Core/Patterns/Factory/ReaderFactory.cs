using LibrarySystem.Core.Models;

namespace LibrarySystem.Core.Patterns.Factory
{
    public static class ReaderFactory
    {
        public static Reader CreateReader(string name, string id = "")
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                id = IdGenerator.Generate("R");
            }

            return new Reader(id, name);
        }
    }
}