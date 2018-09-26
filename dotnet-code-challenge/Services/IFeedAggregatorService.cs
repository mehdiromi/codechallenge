using dotnet_code_challenge.Models;
using System.Collections.Generic;

namespace dotnet_code_challenge.Services
{
    public interface IFeedAggregatorService
    {
        IEnumerable<HorseDetailsModel> GetAllHorsePrices();
    }
}
