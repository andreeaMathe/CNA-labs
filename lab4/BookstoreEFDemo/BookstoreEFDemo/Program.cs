using BookstoreEFDemo.DataAccess;
using BookstoreEFDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreEFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookRepository = new BookRepository();
            bookRepository.Add(new Book() { Title = "something"});

            Console.WriteLine("After inserting, books: ");
            var books = bookRepository.GetAll();
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }

        }
    }
}
