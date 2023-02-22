using Library_ManagementAPI.Services.BookSevice;
using Microsoft.AspNetCore.Mvc;

namespace Library_ManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BookController : Controller
    {
        private readonly IBookService _bookService;
    
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<BooksModels>>> GetAllBooks()
        {
           
           return await _bookService.GetAllBooks();
         
        }
        [HttpGet("{booktitle}")]
        public async Task<ActionResult<List<BooksModels>>> GetBooks(string booktitle, string booksubtitle="", 
                                                                    string bookautor = "", string bookgenres = "", 
                                                                    string bookpublisher = "", string bookedition = "")
        {

            var result = await _bookService.GetBooks(booktitle, booksubtitle, bookautor, bookgenres,
                                                          bookpublisher, bookedition);
            if (result == null)
                return NotFound("Book not found.");

            return Ok(result);

        }
        [HttpGet("id")]
        public async Task<ActionResult<List<BooksModels>>> GetBooksGenres(string bookgenres = "")
        {
            var result = await _bookService.GetBooksGenres(bookgenres);
            if (result == null)
                return NotFound("No book with this genre");
            return Ok(result);

        }
        [HttpPost]
        public async Task<ActionResult<List<BooksModels>>> AddBook(BooksModels book)
        {
            var result = await _bookService.AddBooks(book);
            return Ok(result);

        }
        [HttpPut("{booktitle}")]
        public async Task<ActionResult<List<BooksModels>>> UpdBooks(string booktitle, BooksModels request)
        {
            var result = await _bookService.UpdBooks(booktitle,request);
            if (result == null)
                return NotFound("Book not found.");

            return Ok(result);

        }
        [HttpDelete("{booktitle}")]
        public async Task<ActionResult<List<BooksModels>>> DelBooks(string booktitle)
        {
            var result = await _bookService.DelBooks(booktitle);
            if (result == null)
                return NotFound("Book not found.");

            return Ok(result);
        }

    }
}
