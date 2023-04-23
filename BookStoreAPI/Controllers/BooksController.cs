using BookStore.Data.Interfaces;
using BookStore.Data.Models;
using BookStore.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {


        private IBookRepository books;

        public BooksController(IBookRepository _books)
        {
            this.books = _books;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            return books.GetAllBooks();
        }

        [HttpGet("{id}")]

        public ActionResult<Book> GetBook(int id)
        {
            var book = books.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        [HttpPost]

        public ActionResult<Book> AddNewBook(Book book)
        {
            if (books.AddNewBook(book))
            {
                return book;
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Book>> UpdateBook(int id, Book book)
        {
            var ubook = books.UpdateBook(id, book);
            if (ubook != null)
            {
                return ubook;
            }
            return NotFound();
        }
    }
}
