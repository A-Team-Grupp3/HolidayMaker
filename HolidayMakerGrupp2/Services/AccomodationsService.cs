using HolidayMakerGrupp2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerGrupp2.Services
{
    public static class AccomodationsService
    {
        



        public static async Task<IEnumerable<Accomodation>> Get()
        {
            using var ctx = new HolidayMakerGrupp2Context();


            return await ctx.Accomodations.AsAsyncEnumerable().ToListAsync();


        }

        
    }
}
