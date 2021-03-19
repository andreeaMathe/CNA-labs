using BookstoreEFDemo.DataMapper;
using BookstoreEFDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreEFDemo.DataAccess
{
    class AuthorRepository : IRepository<Author>
    {
        public void Add(Author entity)
        {
            var context = new BookstoreContext();
            var dbSet = context.Set<Author>();
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public IEnumerable<Author> GetAll()
        {
            var context = new BookstoreContext();
            var authors = context.Set<Author>().ToList();
            return authors;
        }
    }
}
