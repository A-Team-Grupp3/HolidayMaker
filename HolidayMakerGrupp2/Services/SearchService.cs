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
            //IEnumerable<Accomodation> accomodation;
            var cityId = _context.Cities.Where(c => c.Name == city).Single<City>();
            var living = _context.Accomodations.ToList();
            List<Accomodation> result = new List<Accomodation>();
            //for (int i = 0; i < living.Count; ++i)
            //{
            //    if (living[i].CityId != cityId.Id)
            //    {
            //        living.RemoveAt(i);
            //    }
            //}
            foreach (var place in living)
            {
                if (place.CityId == cityId.Id)
                {
                    result.Add(place);
                }
            }

            return result;
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
