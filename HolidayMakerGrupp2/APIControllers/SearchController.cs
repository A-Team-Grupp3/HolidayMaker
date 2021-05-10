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

        // GET api/<SearchController>/5
        [HttpGet("{city}")]
        public async Task<IEnumerable<Accomodation>> Get(string city)
        {
            return await SearchService.Search(city);
        }

        [HttpGet("{city}/{arrivalDate}")]
        public async Task<IEnumerable<Accomodation>> Get(DateTime arrivalDate, string city)
        {
            return await SearchService.Search(arrivalDate, city);
        }

        [HttpGet("{city}/{arrivalDate]/{departureDate}")]
        public async Task<IEnumerable<Accomodation>> Get(DateTime arrivalDate, DateTime departureDate, string city)
        {
            return await SearchService.Search(arrivalDate, departureDate, city);
        }
    }
}