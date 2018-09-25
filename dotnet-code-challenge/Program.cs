using dotnet_code_challenge.Models;
using dotnet_code_challenge.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = RegisterServices();

            var feedAggregatorService = serviceProvider.GetService<IFeedAggregatorService>();
            var horses = feedAggregatorService.GetAllHorsePrices();
           
            Print(horses.OrderBy(p => p.Price));

            Console.ReadKey();
        }

        private static ServiceProvider RegisterServices()
        {
            //setup DI
            return new ServiceCollection()

                .AddTransient<IFeedAggregatorService, FeedAggregatorService>()
                .AddTransient<IFeedService, Test1>()
                .AddTransient<IFeedService, Test2>()
                .BuildServiceProvider();
        }

        public class Test1 : IFeedService
        {
            public IEnumerable<HorseDetailsModel> GetHorses()
            {
                return new List<HorseDetailsModel>
                {
                    new HorseDetailsModel("a",1),
                    new HorseDetailsModel("b",5),
                    new HorseDetailsModel("c",2),
                };
            }
        }

        public class Test2 : IFeedService
        {
            public IEnumerable<HorseDetailsModel> GetHorses()
            {
                return new List<HorseDetailsModel>
                {
                    new HorseDetailsModel("d", 10),
                    new HorseDetailsModel("b", 0),
                    new HorseDetailsModel("x", 8),
                };
            }
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
