using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayMakerGrupp2.Models.Database;

namespace HolidayMakerGrupp2.Services
{
    public class SearchService
    {
        private readonly HolidayMakerGrupp2Context _context;

        public SearchService(HolidayMakerGrupp2Context ctx)
        {
            _context = ctx;
        }

        public IEnumerable<Accomodation>SearchByCity(string city)
        {
            
            var cityId = _context.Cities.Where(c => c.Name == city).Select(c => c.Id).FirstOrDefault();
            var acc = _context.Accomodations.Where(a => a.CityId == cityId);
            return acc;
            
        }
    }
}
