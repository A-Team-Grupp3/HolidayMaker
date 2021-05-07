using HolidayMakerGrupp2.Models.Database;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HolidayMakerGrupp2.Services
{
    public static class SearchService
    {
        public static async Task<IEnumerable<Accomodation>> SearchByCity(string city)
        {
            using var _context = new HolidayMakerGrupp2Context();
            var acc = await _context.Accomodations.Where(c => c.City.Name == city).ToListAsync();

            return acc;
        }
    }
}