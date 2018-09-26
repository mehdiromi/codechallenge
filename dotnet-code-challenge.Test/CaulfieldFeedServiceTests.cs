using dotnet_code_challenge.Models;
using dotnet_code_challenge.Services;
using NSubstitute;
using Shouldly;
using System.Linq;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class CaulfieldFeedServiceTests
    {
        private readonly CaulfieldFeedService _sut;
        private readonly ISerializer _serializer;
        public CaulfieldFeedServiceTests()
        {
            _serializer = Substitute.For<ISerializer>();
            _serializer.XmlDeserializer<CaulfieldFeedModel>(Arg.Any<string>())
                .Returns<CaulfieldFeedModel>(new CaulfieldFeedModel
                {
                    races = new meetingRace[]
                    {
                        new meetingRace
                        {
                            horses = new meetingRaceHorse[]
                            {
                                new meetingRaceHorse
                                {
                                    number = 1,
                                    name = "horse1"
                                },
                                new meetingRaceHorse
                                {
                                    number = 2,
                                    name = "horse2"
                                }
                            },
                            prices = new meetingRacePrice[]
                            {
                                new meetingRacePrice
                                {
                                    horses = new meetingRacePriceHorse[]
                                    {
                                        new meetingRacePriceHorse
                                        {
                                            number = 1,
                                            Price = 1
                                        },
                                        new meetingRacePriceHorse
                                        {
                                            number = 2,
                                            Price = 2
                                        }
                                    }
                                }
                            }
                        }
                    }
                });

            _sut = new CaulfieldFeedService(_serializer);
        }

        [Fact]
        public void CaulfieldFeedService_GetHorsePrices_ShouldReturnAllHorsePrices()
        {
            var allHorsePrices = _sut.GetHorses();
            allHorsePrices.ShouldNotBeNull();
            allHorsePrices.Count().ShouldBe(2);
            allHorsePrices.ShouldContain(x => x.HorseName == "horse1" && x.Price == 1);
            allHorsePrices.ShouldContain(x => x.HorseName == "horse2" && x.Price == 2);
        }
    }
}
