using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_code_challenge.Models
{
    public class HorseDetailsModel
    {
        public string HorseName { get; set; }
        public float Price { get; set; }

        public HorseDetailsModel()
        {

        }

        public HorseDetailsModel(string horseName, float price)
        {
            HorseName = horseName;
            Price = price;
        }

    }
}
