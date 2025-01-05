using Entity;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace BooksCatalogueAPI.Controllers
{

    /// <summary>
    /// BooksCatalogue controlller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksCatalogueController : ControllerBase
    {
        private readonly IBooksCatalogueService _bookCatalogueService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bookCatalogueService"></param>
        public BooksCatalogueController(IBooksCatalogueService bookCatalogueService)
        {
            _bookCatalogueService = bookCatalogueService;
        }

        /// <summary>
        /// Get Books sort by Publisher, AuthorLastName, AuthorFirstName and Title
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BooksEntity))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Get Books sort by AuthorLastName, AuhorFirstName and Title
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BooksEntity))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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


        /// <summary>
        /// Get Total Price of all Books
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TotalPriceResp))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// saves the entire list to the database with only one call to the DB server.
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("books")]
        public async Task<IActionResult> CreateBooks([FromBody] List<CreateBooksRequest> books)
        {
            try
            {
                var result = await _bookCatalogueService.CreateBooks(books);
                if (result.Success) return Ok(result);
                else return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Get Books sort by Publisher, AuthorLastName, AuthorFirstName and Title using stored procedure
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get Books sort by AuthorLastName, AuhorFirstName and Title using stored procedure
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// Get list of books sorted based on the provided request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("sort")]
        public async Task<IActionResult> GenericSort(GetBooksRequest request)
        {
            try
            {
                var result = await _bookCatalogueService.GenericSort(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
