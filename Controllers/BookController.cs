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
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookManager _manager = new BookManager();
        

        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _manager.GetAll();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public Book Get(string isbn13)
        {
            return _manager.GetById(isbn13);
        }

        // POST api/<BookController>
        [HttpPost]
        public Book Post([FromBody] Book book)
        {
            return _manager.Add(book);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public Book Put(string isbn, [FromBody] Book updateBook)
        {
            return _manager.Update(isbn, updateBook);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public Book Delete(string isbn)
        {
            return _manager.Delete(isbn);
        }
    }
}
