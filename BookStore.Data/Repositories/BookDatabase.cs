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
        public List<Book> GetAllBooks()
        {
           return db.Books.ToList();
        }

        public Book GetBook(int id)
        {
            return db.Books.FirstOrDefault(x => x.Id == id);
        }
    }
}
