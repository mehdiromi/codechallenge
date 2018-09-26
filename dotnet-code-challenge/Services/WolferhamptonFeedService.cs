using dotnet_code_challenge.Models;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_code_challenge.Services
{

    public class WolferhamptonFeedService : IFeedService
    {
        private WolferhamptonFeedModel _feedsData;
        private ISerializer _serializer;
        private const string feedFilePath = "FeedData\\Wolferhampton_Race1.json";
        //TODO: move filepath to config file

        public WolferhamptonFeedService(ISerializer serializer)
        {
            _serializer = serializer;
        }

        public IEnumerable<HorseDetailsModel> GetHorses()
        {
            _feedsData = _serializer.JsonDeserializer<WolferhamptonFeedModel>(feedFilePath);

            var horses = _feedsData.RawData.Markets.SelectMany(
                m => m.Selections.Select(
                    x => new HorseDetailsModel
                    {
                        HorseName = x.Tags.name,
                        Price = x.Price
                    }));
            return horses;
        }
    }
}
