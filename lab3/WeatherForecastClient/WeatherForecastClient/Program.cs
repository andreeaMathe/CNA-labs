using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Threading;
using System.Threading.Tasks;
using WeatherForecast;

namespace WeatherForecastClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new WeatherForecasts.WeatherForecastsClient(channel);

            var dataStream = client.GetWeatherStream(new Empty());
            var cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(10)).Token;

            try
            {
                await foreach (var weatherData in dataStream.ResponseStream.ReadAllAsync(cancellationToken))
                {
                    Console.WriteLine(weatherData.DateTimeStamp + ": " + weatherData.DegreesCelsius + "C, humidity "
                        + weatherData.Humidity + "%");
                }
            }
            catch (RpcException e) when (e.StatusCode == StatusCode.Cancelled)
            {
                Console.WriteLine("Stream cancelled by client.");
            }
        }
    }
}
