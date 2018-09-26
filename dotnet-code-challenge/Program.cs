using dotnet_code_challenge.Models;
using dotnet_code_challenge.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServiceProvider serviceProvider = RegisterServices();

                var feedAggregatorService = serviceProvider.GetService<IFeedAggregatorService>();

                var horses = feedAggregatorService.GetAllHorsePrices();

                Print(horses);
            }
            catch (Exception ex)
            {
                Console.Write($"There was an error while trying to run the app. {ex.Message}");
                //TODO: add proper logging
            }

            Console.ReadKey(); //TODO: remove this line
        }

        private static ServiceProvider RegisterServices()
        {
            //setup DI
            return new ServiceCollection()

                .AddTransient<IFeedAggregatorService, FeedAggregatorService>()
                .AddSingleton<ISerializer, Serializer>()
                .AddTransient<IFeedService, WolferhamptonFeedService>()
                .AddTransient<IFeedService, CaulfieldFeedService>()
                .BuildServiceProvider();
        }

        private static void Print(IEnumerable<HorseDetailsModel> horses)
        {
            foreach (var horse in horses)
            {
                Console.WriteLine($"{horse.HorseName}, {horse.Price}");
            }
        }
    }
}
