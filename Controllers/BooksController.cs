using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRESTService.Managers;
using BookLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookRESTService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksManager _manager = new BooksManager();
        

        // GET: <BooksController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _manager.GetAll();
        }

        // GET <BooksController>/5
        [HttpGet("{isbn13}")]
        public Book Get(string isbn13)
        {
            return _manager.GetByISBN(isbn13);
        }

        // POST <BooksController>
        [HttpPost]
        public Book Post([FromBody] Book book)
        {
            return _manager.Add(book);
        }

        // PUT <BooksController>/5
        [HttpPut("{isbn13}")]
        public Book Put(string isbn13, [FromBody] Book updateBook)
        {
            return _manager.Update(isbn13, updateBook);
        }

        // DELETE <BooksController>/5
        [HttpDelete("{isbn13}")]
        public Book Delete(string isbn13)
        {
            return _manager.Delete(isbn13);
        }
    }
}
