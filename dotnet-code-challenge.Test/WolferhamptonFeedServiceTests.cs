using dotnet_code_challenge.Models;
using dotnet_code_challenge.Services;
using NSubstitute;
using Shouldly;
using System.Linq;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class WolferhamptonFeedServiceTests
    {
        private WolferhamptonFeedService _sut;
        private readonly ISerializer _serializer;
        public WolferhamptonFeedServiceTests()
        {
            _serializer = Substitute.For<ISerializer>();
            _serializer.JsonDeserializer<WolferhamptonFeedModel>(Arg.Any<string>())
                .Returns<WolferhamptonFeedModel>(new WolferhamptonFeedModel
                {
                    RawData = new Rawdata
                    {
                        Markets = new Market[]
                       {
                           new Market
                           {
                               Selections = new Selection[]
                               {
                                   new Selection
                                   {
                                       Price = 1,
                                       Tags = new SelectionTags
                                       {
                                           name = "horse1"
                                       }
                                   },
                                   new Selection
                                   {
                                       Price = 2,
                                       Tags = new SelectionTags
                                       {
                                           name = "horse2"
                                       }
                                   }
                               }
                           }
                       }

                    }
                });

            _sut = new WolferhamptonFeedService(_serializer);
        }

        [Fact]
        public void WolferhamptonFeedService_GetHorsePrices_ShouldReturnAllHorsePrice()
        {
            var allHorsePrices = _sut.GetHorses();
            allHorsePrices.ShouldNotBeNull();
            allHorsePrices.Count().ShouldBe(2);
            allHorsePrices.ShouldContain(x => x.HorseName == "horse1" && x.Price == 1);
            allHorsePrices.ShouldContain(x => x.HorseName == "horse2" && x.Price == 2);
        }
    }
}
