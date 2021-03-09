using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace BookClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Bookstore.BookstoreClient(channel);

            //add new book
            var bookToBeAdded = new Book() { Title = "Poems" };
            var response = await client.AddBookAsync(
                              new AddBookRequest { Book = bookToBeAdded });
            Console.WriteLine("Adding status: " + response.Status);

            //get books from server
            var responseGetAll = await client.GetAllBooksAsync(new Empty());
            Console.WriteLine("Books from server: " + responseGetAll);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
