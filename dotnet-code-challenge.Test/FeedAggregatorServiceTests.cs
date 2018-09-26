using System;
using Xunit;
using NSubstitute;
using Shouldly;
using dotnet_code_challenge.Services;
using System.Collections.Generic;
using dotnet_code_challenge.Models;
using System.Linq;

namespace dotnet_code_challenge.Test
{
    public class FeedAggregatorServiceTests
    {
        private FeedAggregatorService _sut;
        public FeedAggregatorServiceTests()
        {
            _sut = new FeedAggregatorService(
                new List<IFeedService>()
                {
                    new Feed1(),
                    new Feed2()
                });
        }

        [Fact]
        public void GetAllHorsePricvess_Should_Return_AllHorsesFromAllFeeds()
        {
            var allHorsePrices = _sut.GetAllHorsePrices();
            allHorsePrices.ShouldNotBeNull();
            allHorsePrices.Count().ShouldBe(6);
            allHorsePrices.First().HorseName.ShouldBe("b");
            allHorsePrices.Last().HorseName.ShouldBe("d");
            allHorsePrices.First().Price.ShouldBe(0);
            allHorsePrices.Last().Price.ShouldBe(10);
        }
    }


    public class Feed1 : IFeedService
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

    public class Feed2 : IFeedService
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

}
