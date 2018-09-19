using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/Books")]
    public class BooksController : Controller
    {
        private readonly List<Book> books;
        public BooksController()
        {
            Book book1 = new Book
            {
                Id = 1,
                Name = "Book 1",
                Author = "Arthur Example",
                ReleaseYear = 2017
            };
            Book book2 = new Book
            {
                Id = 2,
                Name = "Book 2, the example",
                Author = "Lisa Writer",
                ReleaseYear = 2012
            };
            Book book3 = new Book
            {
                Id = 3,
                Name = "Cook Book",
                Author = "Terry Chef",
                ReleaseYear = 2001
            };
            books = new List<Book>
            {
                book1,
                book2,
                book3
            };
        }
        // GET: api/Book
        [HttpGet]
        public object Get()
        {
            return books;
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var item = books.FirstOrDefault(b => b.Id == id);
            if(item == null)
            {
                return BadRequest();
            }
            return new ObjectResult(item);
        }
    }
}
