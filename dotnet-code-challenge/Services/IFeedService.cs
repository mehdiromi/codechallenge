using System;
using System.Collections.Generic;
using System.Text;
using dotnet_code_challenge.Models;

namespace dotnet_code_challenge.Services
{
    public interface IFeedService
    {

        IEnumerable<HorseDetailsModel> GetHorses();

    }
}