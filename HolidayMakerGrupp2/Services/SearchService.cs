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
            //IEnumerable<Accomodation> accomodation;
            var cityId = _context.Cities.Where(c => c.Name.Contains(city));
            List<City> result = cityId.ToList();
            foreach  (var accomodation in result)
            {
                accomodation.Name = _context.Cities.Where(c => c.Name.Contains());
            }
            return result;
        }
    }
}
