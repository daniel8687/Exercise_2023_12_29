using Exercise_2023_12_29.Server.Models;
using Exercise_2023_12_29.Server.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Exercise_2023_12_29.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

       

        [HttpPost(Name = "PostGetBooksInfo")]
        public IEnumerable<Book> PostGetBooksInfo([FromBody] string[] isbnArray)
        {
            return _bookService.GetBooks(isbnArray);
        }
    }
}
