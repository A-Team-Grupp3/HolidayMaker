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
            var acc = await _context.Accomodations.AsAsyncEnumerable().Where(c => c.City.Name == city).ToListAsync();

            return acc;
        }

        public static async Task<IEnumerable<Accomodation>> SearchByDate(DateTime date, string city)
        {
            List<Accomodation> accomodations = new();
            using var _context = new HolidayMakerGrupp2Context();
            var acc = await _context.Accomodations.AsAsyncEnumerable().Where(c => c.City.Name == city).ToListAsync();
            // Iterera genom listan med boenden
            int bookedRoom = 0;

            foreach (var a in acc)
            {
                foreach(var book in a.Bookings)
                {
                    if(book.ArrivalDate >= date && book.DepartureDate > date)
                    {
                        ++bookedRoom;
                    }

                }
                if(bookedRoom < a.NrOfRooms)
                {
                    accomodations.Add(a);
                }
                
            }


            return accomodations;
        }
    }
}