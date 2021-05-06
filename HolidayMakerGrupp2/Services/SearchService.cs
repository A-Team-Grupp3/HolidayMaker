using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayMakerGrupp2.Models.Database;

namespace HolidayMakerGrupp2.Services
{
    public class SearchService
    {
        private HolidayMakerGrupp2Context _context = new HolidayMakerGrupp2Context();

        public SearchService()
        {

        }

        public IEnumerable<Accomodation>SearchByCity(string city)
        {
            
            var cityId = _context.Cities.Where(c => c.Name == city).Select(c => c.Id).FirstOrDefault();
            var acc = _context.Accomodations.Where(a => a.CityId == cityId);
            return acc;
            
        }

        //public IEnumerable<Accomodation> SearchByCity(string city)
        //{
        //    //IEnumerable<Accomodation> accomodation;
        //    var cityId = _context.Accomodations.Where(c => c.City.Name == city);
        //    List<Accomodation> result = cityId.ToList();
        //    foreach (var accomodation in result)
        //    {
        //        accomodation.CityId = _context.Cities.Where(p => p.Name == cityId);
        //    }

        //    return result;

        //}
    }
}
