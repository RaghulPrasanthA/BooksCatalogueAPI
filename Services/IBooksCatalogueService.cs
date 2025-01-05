using Data.Models;
using Entity;

namespace Services
{
    public interface IBooksCatalogueService
    {
        Task<List<BooksEntity>> GetSortedBooksByPublisher();
        Task<List<BooksEntity>> GetSortedBooksByAuthorName();
        Task<TotalPriceResp> GetTotalPrice();
        Task<List<BooksEntity>> GetSortedByPublisherSp();
        Task<List<BooksEntity>> GetSortedByAuthorSp();
        Task<PostResponse> CreateBooks(List<CreateBooksRequest> books);

    }

}