using BookMate.Data_Models;
using BookMate.Services_Interfaces;
using BookMate.Services_Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        public readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("all")]
        public ActionResult<List<Book>> GetAllBooks()
        {
            var booksList = _bookService.GetAllBooks();

            if (booksList.Count > 0)
            {
                return Ok(booksList);
            }
            else
            {
                return NotFound("No books avaiable currently!");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book != null)
            {
                return Ok(book);
            }
            else
            {
                return NotFound("No book found with the provided id");
            }
        }

        [HttpPost("create")]
        public IActionResult AddBook([FromBody] Book book)
        {
            _bookService.AddBook(book);
            return Ok();
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book) 
        {
            var status = _bookService.UpdateBook(id, book);
            string statusText = status.ToString();

            if (statusText == "updated")
            {
                return Ok();
            }
            else
            {
                return NotFound("error occured , try again with a valid book id or something!");

            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteBook(int id)
        {
            var status = _bookService.DeleteBook(id);
            string statusText = status.ToString();

            if (statusText == "Deleted")
            {
                return Ok();
            }
            else
            {
                return NotFound("Not found any book with provided book id!");
            }
            
        }

        [HttpGet("hi")]
        public string SayHello()
        {
            return "hi from notification donor class";
        } //this is for testing purposes




        //this following approach is when we are using a database 
        //please consider this is code below this text is written for demonstration purposes


        //private readonly IBook _bookService;

        //private List<Book> _book = new List<Book>();

        //public BookController(IBook bookService)
        //{
        //    _bookService = bookService;
        //}

        //[HttpGet("hi")]
        //public string SayHello()
        //{
        //    return "hi from notification donor class";
        //} //this is for testing purposes

        //[HttpGet("all")]
        //public async Task<ActionResult<List<Book>>> GetAllBooks()
        //{
        //    var bookList = await _bookService.GetAllBooks();
        //    if (bookList.Count > 0)
        //    {
        //        return Ok(bookList);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }

        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Book>> GetById(int id)
        //{
        //    var currentBook = await _bookService.GetById(id);

        //    if (currentBook != null)
        //    {
        //        return Ok(currentBook);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //[HttpPost("create")]
        //public async Task<ActionResult<string>> AddNewBook(Book newBook) 
        //{
        //    await _bookService.AddBook(newBook);
        //    return Ok();
        //}

        //[HttpPut("update/{id}")]
        //public async Task<ActionResult<string>> UpdateBookById(int id, Book book)
        //{
        //    var status = _bookService.UpdateBookById(id, book);
        //    string statusText = status.ToString();
        //    if (statusText == "Update successfull")
        //    {
        //        return Ok("Update successfull");
        //    }
        //    else
        //    { 
        //        return NotFound("Your book couldn't find");
        //    }
        //}

        //[HttpDelete("delete")]
        //public async Task<IActionResult> DeleteById(int id)
        //{
        //    var currentBook = await _bookService.GetById(id);
        //    if (currentBook != null)
        //    {
        //        await _bookService.DeleteBookById(id);
        //        return Ok("Deleted successfully");
        //    }

        //    else
        //    {
        //        return NotFound("No book found with the id provided!");
        //    }
        //}

    }
}
