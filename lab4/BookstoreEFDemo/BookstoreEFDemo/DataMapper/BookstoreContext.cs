using BookstoreEFDemo.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreEFDemo.DataMapper
{
    public class BookstoreContext : DbContext
    {
        public BookstoreContext() : base("bookstoreConnectionString") { }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
    }
}
