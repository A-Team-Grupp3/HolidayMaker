using HolidayMakerGrupp2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerGrupp2.Services
{
    public static class AccomodationsService
    {
        private static HolidayMakerGrupp2Context ctx = new HolidayMakerGrupp2Context();



        public static async Task<IEnumerable<Accomodation>> Get()
        {
            using var ctx = new HolidayMakerGrupp2Context();


            return await ctx.Accomodations.AsAsyncEnumerable().ToListAsync();


        }

        public static async Task<IEnumerable<Accomodation>> GetById(int id)
        {
            using var ctx = new HolidayMakerGrupp2Context();



            var accomodation = await ctx.Accomodations.AsAsyncEnumerable().Where(c => c.Id == id).ToListAsync();


            return accomodation;

        }

        
    }
}
