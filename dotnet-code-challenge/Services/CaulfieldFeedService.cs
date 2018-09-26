using System;
using System.Collections.Generic;
using System.Text;
using dotnet_code_challenge.Models;
using System.Linq;
namespace dotnet_code_challenge.Services
{

    public class CaulfieldFeedService : IFeedService
    {
        private CaulfieldFeedModel _feedsData;
        private ISerializer _serializer;
        private const string feedFilePath = "FeedData\\Caulfield_Race1.xml";

        public CaulfieldFeedService(ISerializer serializer)
        {
            _serializer = serializer;
        }

        public IEnumerable<HorseDetailsModel> GetHorses()
        {
            _feedsData = _serializer.XmlDeserializer<CaulfieldFeedModel>(feedFilePath);

            var horses = _feedsData.races.SelectMany
                (race => race.horses);

            var horsesWithPrice = _feedsData.races.SelectMany(
                race =>
                race.prices.SelectMany(
                    price =>
                    price.horses.Select(
                        horse => new HorseDetailsModel
                        {
                            Price = horse.Price,
                            HorseName = horses.SingleOrDefault(
                                h => h.number == horse.number)?
                                .name ?? "[UNKNOWN]"
                        }

                        )));
            return horsesWithPrice;
        }
    }
}
