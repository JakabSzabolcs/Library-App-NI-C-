using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi_Common.Models;
using WebApi_Server.Repositories;

namespace WebApi_Server.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            var books = BookRepository.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> Get(long id)
        {
            var book = BookRepository.GetBook(id);

            if (book != null)
            {
                return Ok(book);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult Post(Book book)
        {
            BookRepository.AddBook(book);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Book book, long id)
        {
            var bookToUpdate = BookRepository.GetBook(id);

            if (bookToUpdate != null)
            {
                BookRepository.UpdateBook(book);
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var bookToDelete = BookRepository.GetBook(id);

            if (bookToDelete != null)
            {
                BookRepository.DeleteBook(bookToDelete);
                return Ok();
            }

            return NotFound();
        }
    }
}
