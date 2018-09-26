using dotnet_code_challenge.Models;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_code_challenge.Services
{

    public interface IFeedAggregatorService
    {
        IEnumerable<HorseDetailsModel> GetAllHorsePrices();
    }

    public class FeedAggregatorService : IFeedAggregatorService
    {
        private readonly IEnumerable<IFeedService> _feedServices;

        public FeedAggregatorService(IEnumerable<IFeedService> feedServices)
        {
            _feedServices = feedServices;
        }

        public IEnumerable<HorseDetailsModel> GetAllHorsePrices()
        {
            IEnumerable<HorseDetailsModel> horses = new List<HorseDetailsModel>();
            foreach (var feedService in _feedServices)
            {
                horses = horses.Concat(feedService.GetHorses());

            }

            return horses.OrderBy(p => p.Price);
        }
    }
}
