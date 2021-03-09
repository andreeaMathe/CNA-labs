using System;
using System.Collections.Generic;
using System.IO;

namespace BookService.DataAccess
{
    public class BookOperations
    {
        private readonly String filePath = "./Resources/books.txt";

        public bool AddBook(Book book)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine(book.Title);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return false;
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            return true;
        }

        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();

            String line;
            try
            {
                StreamReader sr = new StreamReader(filePath);
                line = sr.ReadLine();
                while (line != null)
                {
                    books.Add(new Book() { Title = line });

                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            return books;
        }
    }
}
