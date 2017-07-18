﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfoWithAPI.Models;
using CityInfoWithAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityInfoWithAPI.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        private ICityInfoRepository _cityInfoRepository;
        [HttpGet()]
        public IActionResult GetCities()
        {
            //return Ok(CitiesDataStore.Current.Cities);
            var cityEntities = _cityInfoRepository.GetCities();
            var results=new List<CityWithoutPointsOfInterestDto>();

            foreach (var cityEntity in cityEntities)
            {
                results.Add(new CityWithoutPointsOfInterestDto
                {
                    Id = cityEntity.Id,
                    Description = cityEntity.Description,
                    Name = cityEntity.Name
                });
            }

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointsOfInterest=false)
        {

            var city = _cityInfoRepository.GetCity(id, includePointsOfInterest);
            if (city == null)
            {
                return NotFound();
            }
            if (includePointsOfInterest)
            {
                var cityResult=new CityDto()
                {
                    Id=city.Id,
                    Name=city.Name,
                    Description = city.Description

                };
                foreach (var poi in city.PointsOfinterests)
                {
                    cityResult.PointsOfInterest.Add(
                        new PointOfInterestDto()
                        {
                            Id = poi.Id,
                            Name=poi.Name,
                            Description = poi.Description
                        });
                }
                return Ok(cityResult);
            }

            var cityWithoutPointsOfInterestResult=new CityWithoutPointsOfInterestDto()
            {
                Id=city.Id,
                Description = city.Description,
                Name=city.Name
            };
            return Ok(cityWithoutPointsOfInterestResult);
//            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
//            if (cityToReturn == null)
//            {
//                return NotFound();
//            }
//
//            return Ok(cityToReturn);
        }
    }
}
