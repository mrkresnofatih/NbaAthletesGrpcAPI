using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using NbaAthletesGrpcAPI.API;

namespace NbaAthletesGrpcAPI.GrpcRunner
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("http://localhost:5000");
            var clientGreet = new Greeter.GreeterClient(channel);
            var responseGreet = await clientGreet.SayHelloAsync(new HelloRequest
            {
                Name = "Irham & Zaki"
            });
            Console.WriteLine("From Server: " + responseGreet.Message);

            var clientBook = new Booker.BookerClient(channel);
            var responseBook = await clientBook.SaveBookAsync(new BookCreateRequest
            {
                Author = "Kresno Fatih Imani",
                Pages = 234,
                Title = "How to code w/ C#"
            });
            Console.WriteLine("From BookServer: " + responseBook.Id);
        }
    }
}
