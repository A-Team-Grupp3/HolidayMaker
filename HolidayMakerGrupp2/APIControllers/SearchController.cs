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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SearchController>/5
        [HttpGet("{city}")]
        public async Task<IEnumerable<Accomodation>> GetByCity(string city)
        {
            return await SearchService.SearchByCity(city);
        }
    }
}