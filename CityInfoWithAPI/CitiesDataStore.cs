using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfoWithAPI.Models;

namespace CityInfoWithAPI
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; }=new CitiesDataStore();
        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            //init dummy data

            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "It has a huge park."
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "It has a not finished cathedral."
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Paris",
                    Description = "It has Eiffel Tower."
                }
            };
        }

    }
}
