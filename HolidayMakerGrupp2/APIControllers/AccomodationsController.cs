using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HolidayMakerGrupp2.Models.Database;
using HolidayMakerGrupp2.Services;

namespace HolidayMakerGrupp2.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccomodationsController : ControllerBase
    {


        public AccomodationsController()
        {

        }


        [HttpGet("{id}")]
        public async Task<IEnumerable<Accomodation>> Get(int id)
        {
            if (int.Equals(id, 0))
            {
                return await AccomodationsService.Get();
            }
            else
            {
                return await AccomodationsService.GetById(id);
            }

        }


    }
}
