using BookService.DataAccess;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Services
{
    public class BookService : Bookstore.BookstoreBase
    {
        private readonly BookOperations bookOperations = new BookOperations();
        private readonly ILogger<BookService> _logger;
        public BookService(ILogger<BookService> logger)
        {
            _logger = logger;
        }

        public override Task<AddBookResponse> AddBook(AddBookRequest request, ServerCallContext context)
        {
            var book = request.Book;
            var books = bookOperations.AddBook(book);

            _logger.Log(LogLevel.Information, "Added book: " + book.Title);

            return Task.FromResult(new AddBookResponse() { Status = AddBookResponse.Types.Status.Success });
        }
            
        public override Task<GetAllBooksResponse> GetAllBooks(Empty request, ServerCallContext context)
        {
            _logger.Log(LogLevel.Information, "GetAllBooks called");

            //var books = new List<Book>() {
            //new Book() { Title = "Homo Deus"},
            //new Book() { Title = "Sapiens"}
            //};
            var books = bookOperations.GetAllBooks();

            var response = new GetAllBooksResponse();
            response.Books.AddRange(books);

            return Task.FromResult(response);
        }
    }
}
