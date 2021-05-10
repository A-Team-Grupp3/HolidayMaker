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
            var acc = await _context.Accomodations.AsQueryable().Where(a => a.City.Name == city).ToListAsync();

            return acc;
        }

        public static async Task<IEnumerable<Accomodation>> SearchByDate(DateTime date, string city)
        {
            List<Accomodation> accomodations = new();
            using var _context = new HolidayMakerGrupp2Context();
            var acc = await _context.Accomodations.AsQueryable().Where(c => c.City.Name == city).ToListAsync();
            // Iterera genom listan med boenden
            foreach (var a in acc)
            {
                // kolla i databasen om antalet rum där ankomstdagen är samma som datumet är lika med max antal rum för boendet.
                var roomsInBooking = await _context.RoomInBookings.AsAsyncEnumerable().Where(r => r.Room.Accomodations == a).Where(r => r.Booking.ArrivalDate == date).ToListAsync();
                if (!(roomsInBooking.Count == a.NrOfRooms))
                    accomodations.Add(a);
            }

            return accomodations;
        }
    }
}