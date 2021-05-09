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

        public static async Task<IEnumerable<Accomodation>> SearchByDate(DateTime date, string city)
        {
            List<Accomodation> accomodations = new();
            using var _context = new HolidayMakerGrupp2Context();
            var acc = await _context.Accomodations.Where(c => c.City.Name == city).ToListAsync();
            // Iterera genom listan med boenden
            foreach (var a in acc)
            {
                // kolla i databasen om antalet rum där ankomstdagen är samma som datumet är lika med max antal rum för boendet.
                var roomsInBooking = await _context.RoomInBookings.Where(r => r.Room.Accomodations == a).Where(r => r.Booking.ArrivalDate == date).ToListAsync();
                if (!(roomsInBooking.Count == a.NrOfRooms))
                    accomodations.Add(a);
                // Gör samma fast med avresesdatum
                roomsInBooking = await _context.RoomInBookings.Where(r => r.Room.Accomodations == a).Where(r => r.Booking.DepartureDate == date).ToListAsync();
                if (!(roomsInBooking.Count == a.NrOfRooms))
                    accomodations.Add(a);
            }

            //foreach(var acco in acc)
            //{
            //   foreach(var room in acco.Rooms)
            //   {
            //        foreach(var rb in room.RoomInBookings)
            //        {
            //            if(rb.Booking.DepartureDate.CompareTo(date) < 0)
            //            {
            //                accomodations.Add(acco);
            //            }
            //        }
            //   }
            //}
            return accomodations;
        }
    }
}