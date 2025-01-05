using AutoMapper;
using Data;
using Data.Models;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Services
{

    public class BooksCatalogueService : IBooksCatalogueService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BooksCatalogueService(AppDbContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;
        }

        public async Task<List<BooksEntity>> GetSortedBooksByPublisher()
        {
            try
            {
                return await _context.Books
               .OrderBy(b => b.Publisher)
               .ThenBy(b => b.AuthorLastName)
               .ThenBy(b => b.AuthorFirstName)
               .ThenBy(b => b.Title).Select(b => _mapper.Map<BooksEntity>(b)).ToListAsync();
            }
            catch (Exception) { throw; }//Handle exceptions as per project requirements later 
        }

        public async Task<List<BooksEntity>> GetSortedBooksByAuthorName()
        {
            try
            {
                return await _context.Books
                .OrderBy(b => b.AuthorLastName)
                .ThenBy(b => b.AuthorFirstName)
                .ThenBy(b => b.Title).Select(b => _mapper.Map<BooksEntity>(b)).ToListAsync();
            }
            catch (Exception) { throw; }//Handle exceptions as per project requirements later 

        }

        public async Task<TotalPriceResp> GetTotalPrice()
        {
            try
            {
                var totalPrice = await _context.Books.SumAsync(b => b.Price);
                return new TotalPriceResp { totalPrice = totalPrice.ToString() };
            }
            catch (Exception) { throw; }//Handle exceptions as per project requirements later

        }

        public async Task<PostResponse> CreateBooks(List<CreateBooksRequest> books)
        {
            try
            {
                var resp = new PostResponse();
                if (books == null || books.Count == 0)
                {
                    resp.Message = "There is nothing to insert";
                    return resp;
                }
                else
                {
                    var newBooks = _mapper.Map<List<Books>>(books);
                    _context.Books.AddRange(newBooks);
                    await _context.SaveChangesAsync();
                    resp.Success = true;
                    resp.Message = "Saved Successfully";
                    return resp;
                }
            }
            catch (Exception) { throw; }//Handle exceptions as per project requirements later 

        }

        public async Task<List<BooksEntity>> GetSortedByPublisherSp()
        {
            try
            {
                var data = await _context.Books.FromSqlRaw("EXEC GetBooksSortedByPublisherAuthorTitle").ToListAsync();
                return data.Select(b => _mapper.Map<BooksEntity>(b)).ToList();
            }
            catch (Exception) { throw; }//Handle exceptions as per project requirements later 
        }

        public async Task<List<BooksEntity>> GetSortedByAuthorSp()
        {
            try
            {
                var data = await _context.Books.FromSqlRaw("EXEC GetBooksSortedByAuthorTitle").ToListAsync();
                return data.Select(b => _mapper.Map<BooksEntity>(b)).ToList();
            }
            catch(Exception) { throw; }//Handle exceptions as per project requirements later 
        }

        public async Task<List<BooksEntity>> GenericSort(GetBooksRequest request)
        {
            try
            {
                var resp = new List<BooksEntity>();

                switch (request.SortingOption)
                {
                    case SortingOption.AuthorBasedSorting when request.IsSp:
                        resp = await GetSortedByAuthorSp();
                        break;

                    case SortingOption.PublisherBasedSorting when request.IsSp:
                        resp = await GetSortedByPublisherSp();
                        break;

                    case SortingOption.AuthorBasedSorting when !request.IsSp:
                        resp = await GetSortedBooksByAuthorName();
                        break;

                    case SortingOption.PublisherBasedSorting when !request.IsSp:
                        resp = await GetSortedBooksByPublisher();
                        break;

                    default:
                        // Handle cases if needed 
                        break;
                }

                return resp;
            }
            catch (Exception) { throw; }//Handle exceptions as per project requirements later 
        }

    }
}


