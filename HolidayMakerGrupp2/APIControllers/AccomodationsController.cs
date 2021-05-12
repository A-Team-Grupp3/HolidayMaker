using HolidayMakerGrupp2.Models.Database;
using HolidayMakerGrupp2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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