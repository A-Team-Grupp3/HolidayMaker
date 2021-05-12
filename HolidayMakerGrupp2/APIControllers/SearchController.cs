using HolidayMakerGrupp2.Models.Database;
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

        //    return await SearchService.SearchByCity(city);

        //}

        //GET api/search/byCityAndDistance?city=Malmö&distanceToBeach=0&distanceToCity=0.5
        [HttpGet("byCityAndDistance")]
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
                return await SearchService.Search(city);
            }
        }

        // GET api/search/byCity?city=Malmö
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

        [HttpGet("byArrivalAndDistance")]
        public async Task<IEnumerable<Accomodation>> Get(DateTime arrivalDate, string city, float distanceToBeach, float distanceToCity)
        {
            if (distanceToBeach != 0.0 && distanceToCity != 0.0)
            {
                return await SearchService.Search(arrivalDate, city, distanceToBeach, distanceToCity);
            }
            if (distanceToBeach != 0.0)
            {
                return await SearchService.Search(arrivalDate, city, distanceToBeach);
            }
            if (distanceToCity != 0.0)
            {
                return await SearchService.SearchByCity(arrivalDate, city, distanceToCity);
            }
            else
            {
                return await SearchService.Search(city);
            }
            
        }

        [HttpGet("byArrivalDepartureAndDistance")]
        public async Task<IEnumerable<Accomodation>> Get(DateTime arrivalDate, DateTime departureDate, string city, float distanceToBeach, float distanceToCity)
        {
            if (distanceToBeach != 0.0 && distanceToCity != 0.0)
            {
                return await SearchService.Search(arrivalDate, departureDate, city, distanceToBeach, distanceToCity);
            }
            if (distanceToBeach != 0.0)
            {
                return await SearchService.Search(arrivalDate, departureDate, city, distanceToBeach);
            }
            if (distanceToCity != 0.0)
            {
                return await SearchService.SearchDistanceToCity(arrivalDate, departureDate, city, distanceToCity);
            }
            else
            {
                return await SearchService.Search(city);
            }

        }


    }
}