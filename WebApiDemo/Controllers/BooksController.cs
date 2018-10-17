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
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly BookContext _context;
        public BooksController(BookContext context)
        {
            _context = context;

            if (_context.Books.Count() == 0)
            {
                _context.Books.Add(new Book { Name = "Book 1", Author = "Arthur Example", ReleaseYear = 2017 });
                _context.Books.Add(new Book { Name = "Book 2, the example", Author = "Lisa Writer", ReleaseYear = 2012 });
                _context.Books.Add(new Book { Name = "Cook Book", Author = "Terry Chef", ReleaseYear = 2001 });
                _context.SaveChanges();
            }
        }
        // GET: api/Books
        [HttpGet]
        public object Get()
        {
            return _context.Books.ToList();
        }

        // GET: api/Books/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var item = _context.Books.FirstOrDefault(b => b.Id == id);
            if (item == null)
            {
                return BadRequest();
            }
            return new ObjectResult(item);
        }

        // POST: api/Books
        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            if (String.IsNullOrEmpty(book.Name))
                book.Name = "Unknown book";
            if (String.IsNullOrEmpty(book.Author))
                book.Author = "Unknown author";
            if (book.ReleaseYear == 0)
                book.ReleaseYear = 1900;

            _context.Books.Add(book);
            _context.SaveChanges();

            return CreatedAtRoute("Get", new { id = book.Id }, book);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Book book)
        {
            var item = _context.Books.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            item.Name = book.Name;
            item.Author = book.Author;
            item.ReleaseYear = book.ReleaseYear;

            _context.Books.Update(item);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Books.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Books.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
