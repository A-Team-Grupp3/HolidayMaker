using HolidayMakerGrupp2.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerGrupp2.Services
{
    public static class SearchService
    {
        public static async Task<IEnumerable<Accomodation>> Search(string city)
        {
            using var _context = new HolidayMakerGrupp2Context();
            var acc = await _context.Accomodations.AsQueryable().Where(a => a.City.Name == city).ToListAsync();

            return acc;
        }

        public static async Task<IEnumerable<Accomodation>> Search(DateTime date, string city)
        {
            List<Accomodation> accomodations = new();
            using var _context = new HolidayMakerGrupp2Context();
            var acc = await _context.Accomodations.AsQueryable().Where(c => c.City.Name == city).ToListAsync();
            // Iterera genom listan med boenden
            int bookedRoom = 0;

            foreach (var a in acc)
            {
                foreach (var book in a.Bookings)
                {
                    if (book.ArrivalDate >= date && book.DepartureDate > date)
                    {
                        ++bookedRoom;
                    }
                }
                if (bookedRoom < a.NrOfRooms)
                {
                    accomodations.Add(a);
                }
            }

            return accomodations;
        }

        public static async Task<IEnumerable<Accomodation>> Search(DateTime arrivalDate, DateTime departureDate, string city)
        {
            List<Accomodation> accomodations = new();
            using var _context = new HolidayMakerGrupp2Context();
            var acc = await _context.Accomodations.AsQueryable().Where(c => c.City.Name == city).ToListAsync();
            // Iterera genom listan med boenden
            int bookedRoom = 0;

            foreach (var a in acc)
            {
                foreach (var room in a.Rooms)
                {
                    foreach (var rb in room.RoomInBookings)
                    {
                        if ((rb.Booking.ArrivalDate >= arrivalDate && rb.Booking.DepartureDate > arrivalDate) &&
                            (rb.Booking.ArrivalDate >= departureDate && rb.Booking.DepartureDate > departureDate))
                        {
                            ++bookedRoom;
                        }
                    }
                }
                if (bookedRoom < a.NrOfRooms)
                {
                    accomodations.Add(a);
                }
            }

            return accomodations;
        }

        public static async Task<IEnumerable<Accomodation>> Search()
        {
            using HolidayMakerGrupp2Context _context = new();
            return await _context.Accomodations.AsQueryable().ToListAsync();
        }
    }
}