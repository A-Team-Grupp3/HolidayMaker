using HolidayMakerGrupp2.Models.Database;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

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

        public static async Task<IEnumerable<Accomodation>>SearchByDate(DateTime date, string city)
        {


            using var _context = new HolidayMakerGrupp2Context();
            var acc = await _context.Accomodations.Where(c => c.City.Name == city).ToListAsync();
            List<Accomodation> accomodations = new List<Accomodation>();
            
            foreach(var acco in acc)
            {
               foreach(var room in acco.Rooms)
               {
                    foreach(var rb in room.RoomInBookings)
                    {
                        if(rb.Booking.DepartureDate.CompareTo(date) < 0)
                        {
                            accomodations.Add(acco);
                        }
                    }
               }
            }
            return accomodations;

        }
    }
}