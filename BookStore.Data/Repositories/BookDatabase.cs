using BookStore.Data.Interfaces;
using BookStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Repositories
{
    public class BookDatabase : IBookRepository
    {
        private BookStoreContext db;

        public BookDatabase(BookStoreContext db)
        {
            this.db = db;
        }

        public bool AddNewBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return true;
        }

        public List<Book> GetAllBooks()
        {
           return db.Books.ToList();
        }

        public Book GetBook(int id)
        {
            return db.Books.FirstOrDefault(x => x.Id == id);
        }

        public bool Remove(int id)
        {
            var book = GetBook(id);
            if(book == null)
            {
                return false;
            }
            db.Books.Remove(book);
            db.SaveChanges();
            return true;

        }

        public List<Book> UpdateBook(int id, Book book)
        {
            var _book = db.Books.FirstOrDefault(x => x.Id == id);

            if(_book != null)
            {
                _book.Title = book.Title ?? _book.Title;
                _book.Author = book.Author ?? _book.Author;
                if(book.PublicationYear != null)
                {
                    _book.PublicationYear = book.PublicationYear;
                } else
                {
                _book.PublicationYear = _book.PublicationYear;
                };
                if(book.IsAvailable)
                {
                    _book.IsAvailable = book.IsAvailable;
                } else
                {
                _book.IsAvailable = _book.IsAvailable;
                }
                _book.CallNumber = book.CallNumber ?? _book.CallNumber;

            }
            return db.Books.ToList();

        }
    }
}
