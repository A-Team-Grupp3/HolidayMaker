using HolidayMakerGrupp2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerGrupp2.Services
{
    public class AccomodationsService
    {
        private HolidayMakerGrupp2Context ctx = new HolidayMakerGrupp2Context();

        public AccomodationsService()
        {

        }

        public IEnumerable<Accomodation> Get()
        {
            return ctx.Accomodations.ToList();
        }

        public IEnumerable<Accomodation> GetById(int id)
        {
            var accomodations = ctx.Accomodations.Where(c => c.Id == id);

            return accomodations;
        }

        //public IEnumerable<Accomodation> GetByName(string name)
        //{
        //    if (string.IsNullOrWhiteSpace(name))
        //    {
        //        return ctx.Accomodations.ToList();
        //    }
        //    else
        //    {
        //        return ctx.Accomodations.Where(p => p.Name.ToLower.Contains(name).ToList());
        //    }
        //}
    }
}
