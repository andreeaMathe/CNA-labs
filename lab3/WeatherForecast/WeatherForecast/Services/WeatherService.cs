using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Services
{
    public class WeatherService : WeatherForecasts.WeatherForecastsBase
    {
        public override async Task GetWeatherStream(Empty request, IServerStreamWriter<WeatherData> responseStream, ServerCallContext context)
        {
            Random random = new Random();

            try
            {
                while (!context.CancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(2000);

                    var weatherData = new WeatherData()
                    {
                        DateTimeStamp = Timestamp.FromDateTime(DateTime.UtcNow),
                        DegreesCelsius = random.Next(-20, 35),
                        Humidity = random.NextDouble(),
                        Precipitation = random.NextDouble()
                    };

                    await responseStream.WriteAsync(weatherData);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.Message + "\n");
            }
        }
    }
}
