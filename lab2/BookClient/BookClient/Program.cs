using BookService;
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
            //using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            //var client = new Greeter.GreeterClient(channel);
            //var reply = await client.SayHelloAsync(
            //                  new HelloRequest { Name = "GreeterClient" });
            //Console.WriteLine("Greeting: " + reply.Message);
            //Console.WriteLine("Press any key to exit...");
            //Console.ReadKey();

            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Bookstore.BookstoreClient(channel);

            //var bookToBeAdded = new Book() { Title = "Poems" };
            //var response = await client.AddBookAsync(
            //                  new AddBookRequest { Book = bookToBeAdded });
            //Console.WriteLine("Adding status: " + response.Status);

            var response = await client.GetAllBooksAsync(new Empty());
            Console.WriteLine(response);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
