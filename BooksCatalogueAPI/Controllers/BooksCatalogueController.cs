using Entity;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace BooksCatalogueAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BooksCatalogueController : ControllerBase
    {
        private readonly IBooksCatalogueService _bookCatalogueService;

        public BooksCatalogueController(IBooksCatalogueService bookCatalogueService)
        {
            _bookCatalogueService = bookCatalogueService;
        }
        // 1. Get Books sorted by Publisher, Author (Last, First), and Title
        // GET: api/books/sortByPublisher
        [HttpGet("sortbypublisher")]
        public async Task<IActionResult> GetSortedBooksByPublisher()
        {
            try
            {
                var result = await _bookCatalogueService.GetSortedBooksByPublisher();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // 2. Get Books sorted by Author (Last, First) and Title
        // GET: api/books/sortByAuthortName
        [HttpGet("sortbyauthorname")]
        public async Task<IActionResult> GetSortedBooksByAuthorName()
        {
            try
            {
                var result = await _bookCatalogueService.GetSortedBooksByAuthorName();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // 5. Get Total Price of all Books
        // GET: api/books/totalPrice
        [HttpGet("totalprice")]
        public async Task<IActionResult> GetTotalPrice()
        {
            try
            {
                var result = await _bookCatalogueService.GetTotalPrice();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // 6. If you have a large list of these in memory and want to save the entire list to the database,with only one call to the DB server.
        // POST: api/books/books
        [HttpPost("books")]
        public async Task<IActionResult> CreateBooks([FromBody] List<CreateBooksRequest> books)
        {
            try
            {
                var result = await _bookCatalogueService.CreateBooks(books);
                if (result.success) return Ok(result);
                else return BadRequest(result.message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // 3. Get Books sorted by Publisher, Author (Last, First), and Title
        // GET: api/books/sortByPublisherSP
        [HttpGet("sortbypublishersp")]
        public async Task<IActionResult> GetSortedByPublisherSp()
        {
            try
            {
                var result = await _bookCatalogueService.GetSortedByPublisherSp();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // 3. Get Books sorted by Publisher, Author (Last, First), and Title
        // GET: api/books/sortByPublisherSP
        [HttpGet("sortbyauthorsp")]
        public async Task<IActionResult> GetSortedByAuthorSp()
        {
            try
            {
                var result = await _bookCatalogueService.GetSortedByAuthorSp();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
