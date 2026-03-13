namespace LibrarySystem.Core.Models
{
    public class Reader
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Reader(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}