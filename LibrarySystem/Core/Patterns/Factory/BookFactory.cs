using LibrarySystem.Core.Models;
using LibrarySystem.Core.Patterns.Strategy;

namespace LibrarySystem.Core.Patterns.Factory
{
    public static class BookFactory
    {
        public static Book CreateBook(string title, string author, string type, string id = "")
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                id = IdGenerator.Generate("B");
            }

            // Додав перевірку і на "Rare" (для тестів), і на "Рідкісна" (можливо, для вашого UI)
            IFineStrategy strategy = (type == "Рідкісна" || type == "Rare")
                ? new RareBookFineStrategy()
                : new StandardFineStrategy();

            return new Book(id, title, author, strategy);
        }
    }
}