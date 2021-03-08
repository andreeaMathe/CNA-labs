using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Services
{
    public class BookService : Bookstore.BookstoreBase
    {
        public override Task<AddBookResponse> AddBook(AddBookRequest request, ServerCallContext context)
        {
            var book = request.Book;
            Console.WriteLine("Added book: " + book.Title);

            return Task.FromResult(new AddBookResponse() { Status = AddBookResponse.Types.Status.Success });
        }

        public override Task<GetAllBooksResponse> GetAllBooks(Empty request, ServerCallContext context)
        {
            Console.WriteLine("GetAllBooks called");

            var books = new List<Book>() {
            new Book() { Title = "Homo Deus"},
            new Book() { Title = "Sapiens"}
            };

            var response = new GetAllBooksResponse();
            response.Books.AddRange(books);

            return Task.FromResult(response);
        }
    }
}
