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
            ServiceProvider serviceProvider = RegisterServices();

            var feedAggregatorService = serviceProvider.GetService<IFeedAggregatorService>();
            var horses = feedAggregatorService.GetAllHorsePrices();
           
            Print(horses);

            Console.ReadKey();
        }

        private static ServiceProvider RegisterServices()
        {
            //setup DI
            return new ServiceCollection()

                .AddTransient<IFeedAggregatorService, FeedAggregatorService>()                
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
