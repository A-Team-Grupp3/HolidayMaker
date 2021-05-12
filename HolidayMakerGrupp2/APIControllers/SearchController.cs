﻿using HolidayMakerGrupp2.Models.Database;
using HolidayMakerGrupp2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HolidayMakerGrupp2.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Accomodation>> Get()
        {
            return await SearchService.Search();
        }
        //[HttpGet("{city}")]
        //public async Task<IEnumerable<Accomodation>> GetByCity(string city)
        //{

        //    return await SearchService.SearchByCity(city);

        //}

        //GET api/<SearchController>/5
        [HttpGet("{city}")]
        public async Task<IEnumerable<Accomodation>> GetByCityAndDistance(string city, float distanceToBeach, float distanceToCity)
        {
            if (distanceToBeach > 0.0 && distanceToCity > 0.0)
            {
                return await SearchService.SearchByCityAndDistanceToBeachAndToCity(city, distanceToBeach, distanceToCity);
            }
            else if (distanceToCity > 0.0)
            {
                return await SearchService.SearchByCityAndDistanceToCity(city, distanceToCity);
            }
            else if (distanceToBeach > 0.0)
            {
                return await SearchService.SearchByCityAndDistanceToBeach(city, distanceToBeach);
            }
            else
            {
                return await SearchService.SearchByCity(city);
            }

        }
        [HttpGet("{date}/{city}")]
        public async Task<IEnumerable<Accomodation>> GetByDateAndCity(DateTime date, string city)
        // GET api/<SearchController>/5
        [HttpGet("byCity")]
        public async Task<IEnumerable<Accomodation>> Get(string city)
        {
            return await SearchService.Search(city);
        }

        //api/search/byArrivalDate?arrivaldate=&city=
        [HttpGet("byArrivalDate")]
        public async Task<IEnumerable<Accomodation>> Get(DateTime arrivalDate, string city)
        {
            return await SearchService.Search(arrivalDate, city);
        }

        //api/search/arrivalDeparture?arrivalDate=&departureDate=&city=
        [HttpGet("arrivalDeparture")]
        public async Task<IEnumerable<Accomodation>> Get(DateTime arrivalDate, DateTime departureDate, string city)
        {
            return await SearchService.Search(arrivalDate, departureDate, city);
        }
    }
}