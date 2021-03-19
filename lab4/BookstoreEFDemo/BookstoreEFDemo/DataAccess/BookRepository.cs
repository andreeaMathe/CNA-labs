using BookstoreEFDemo.DataMapper;
using BookstoreEFDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreEFDemo.DataAccess
{
    class BookRepository : IRepository<Book>
    {
        public void Add(Book entity)
        {
            var context = new BookstoreContext();
            var dbSet = context.Set<Book>();
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public IEnumerable<Book> GetAll()
        {
            var context = new BookstoreContext();
            var books = context.Set<Book>().ToList();
            return books;
        }
    }
}
