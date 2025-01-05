namespace Entity
{
    public partial class BooksEntity
    {
        public string? Publisher { get; set; }
        public string? Title { get; set; }
        public string? AuthorLastName { get; set; }
        public string? AuthorFirstName { get; set; }
        public string? Price { get; set; }
        public string? PublishedYear { get; set; }
        public string? City { get; set; }
        public string? MLACitation { get; set; }
        public string? ChicagoStyleCitation { get; set; }
    }

    public partial class CreateBooksRequest
    {
        public string? Publisher { get; set; }
        public string? Title { get; set; }
        public string? AuthorLastName { get; set; }
        public string? AuthorFirstName { get; set; }
        public decimal Price { get; set; }
        public int? Year { get; set; } 
        public string? City { get; set; } 
        public string? JournalTitle { get; set; }
        public string? TitleOfContainer { get; set; }
        public string? PageNumber { get; set; }
        public string? Month { get; set; }
        public string? URL { get; set; }
        public string? Volume { get; set; }

    }

    public partial class TotalPriceResp
    {
        public string? totalPrice { get; set; }
    }

    public partial class PostResponse
    {
        public bool success { get; set; }
        public string? message { get; set; }
    }

    public enum GetRequest
    {
       
    }
}