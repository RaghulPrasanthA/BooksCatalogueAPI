namespace Data.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string? Publisher { get; set; }
        public string? Title { get; set; }
        public string? AuthorLastName { get; set; }
        public string? AuthorFirstName { get; set; }
        public decimal Price { get; set; }
        //additional fields
        public int? Year { get; set; } 
        public string? City { get; set; } 
        public string? JournalTitle { get; set; }
        public string? TitleOfContainer { get; set; }
        public string? PageNumber { get; set; }
        public string? Month { get; set; }
        public string? URL { get; set; }
        public string? Volume { get; set; }
    }
}
