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
            var cityId = _context.Cities.Where(c => c.Name.Contains(city)).Single<City>();
            var living = _context.Accomodations.ToList();
            for (int i = 0; i < living.Count; ++i)
            {
                if (living[i].CityId != cityId.Id)
                {
                    living.RemoveAt(i);
                }
            }

            return living;
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
