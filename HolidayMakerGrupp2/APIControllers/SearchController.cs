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

       

        //api/search/arrivalDeparture?arrivalDate=&departureDate=&city=
        [HttpGet("search")]
        public async Task<IEnumerable<Accomodation>> Get(DateTime arrivalDate, DateTime? departureDate, string city, float? distanceToBeach, float? distanceToCity)
        {

            return await SearchService.Search(arrivalDate, departureDate, city, distanceToBeach, distanceToCity);
        }

        
        

        


    }
}