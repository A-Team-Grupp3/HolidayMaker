﻿using HolidayMakerGrupp2.Models.Database;
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
            var acc = await _context.Accomodations.AsQueryable().Where(c => c.City.Name == city).ToListAsync();

            return acc;
        }

        public static async Task<IEnumerable<Accomodation>> SearchByCityAndDistanceToCity(string city, float distanceToCity)
        {
            using var _context = new HolidayMakerGrupp2Context();
            var acc = await _context.Accomodations.AsQueryable().Where(c => c.City.Name == city).Where(d => d.DistanceDowntown <= distanceToCity).ToListAsync();

            return acc;
        }

        public static async Task<IEnumerable<Accomodation>> SearchByCityAndDistanceToBeach(string city, float distancToBeach)
        {
            using var _context = new HolidayMakerGrupp2Context();
            var acc = await _context.Accomodations.AsQueryable().Where(c => c.City.Name == city).Where(d => d.DistanceBeach <= distancToBeach).ToListAsync();

            return acc;
        }

        public static async Task<IEnumerable<Accomodation>> SearchByCityAndDistanceToBeachAndToCity(string city, float distancToBeach, float distanceToCity)
        {
            using var _context = new HolidayMakerGrupp2Context();
            var acc = await _context.Accomodations.AsQueryable().Where(c => c.City.Name == city).Where(d => d.DistanceBeach <= distancToBeach).Where(t => t.DistanceDowntown <= distanceToCity).ToListAsync();
            return acc;
        }

        public static async Task<IEnumerable<Accomodation>> Search(DateTime date, string city)
        {
            using var _context = new HolidayMakerGrupp2Context();
            List<Accomodation> availableHotels = new();
            var accList = await _context.Accomodations.Include(c => c.City).ToListAsync();
            var bookingsInCity = await GetBookingsAsync(date, null, city, _context);
            foreach (var acc in accList)
            {
                int bookedRooms = 0;

                if (bookingsInCity.Contains(acc.Id))
                {
                    foreach (int b in bookingsInCity)
                    {
                        if (b == acc.Id)
                        {
                            bookedRooms++;
                        }
                    }
                    if (bookedRooms < acc.NrOfRooms)
                        availableHotels.Add(acc);
                }
                if (!availableHotels.Contains(acc) && acc.City.Name == city)
                {
                    availableHotels.Add(acc);
                }
            }

            return availableHotels;
        }

        public static async Task<IEnumerable<Accomodation>> Search(DateTime date, string city, float distanceToBeach)
        {
            using var _context = new HolidayMakerGrupp2Context();
            List<Accomodation> availableHotels = new();
            var accList = await _context.Accomodations.AsQueryable().Where(c => c.DistanceBeach <= distanceToBeach).Include(c => c.City).ToListAsync();
            var bookingsInCity = await GetBookingsAsync(date, null, city, _context);
            foreach (var acc in accList)
            {
                int bookedRooms = 0;

                if (bookingsInCity.Contains(acc.Id))
                {
                    foreach (int b in bookingsInCity)
                    {
                        if (b == acc.Id)
                        {
                            bookedRooms++;
                        }
                    }
                    if (bookedRooms < acc.NrOfRooms)
                        availableHotels.Add(acc);
                }
                if (!availableHotels.Contains(acc) && acc.City.Name == city)
                {
                    availableHotels.Add(acc);
                }
            }
            
            return availableHotels;
        }

        public static async Task<IEnumerable<Accomodation>> SearchByCity(DateTime date, string city, float distanceToCity)
        {
            using var _context = new HolidayMakerGrupp2Context();
            List<Accomodation> availableHotels = new();
            var accList = await _context.Accomodations.AsQueryable().Where(c => c.DistanceDowntown <= distanceToCity).Include(c => c.City).ToListAsync();
            var bookingsInCity = await GetBookingsAsync(date, null, city, _context);
            foreach (var acc in accList)
            {
                int bookedRooms = 0;

                if (bookingsInCity.Contains(acc.Id))
                {
                    foreach (int b in bookingsInCity)
                    {
                        if (b == acc.Id)
                        {
                            bookedRooms++;
                        }
                    }
                    if (bookedRooms < acc.NrOfRooms)
                        availableHotels.Add(acc);
                }
                if (!availableHotels.Contains(acc) && acc.City.Name == city)
                {
                    availableHotels.Add(acc);
                }
            }
            
            return availableHotels;
        }
        public static async Task<IEnumerable<Accomodation>> Search(DateTime date, string city, float distanceToBeach, float distanceToCity)
        {
            using var _context = new HolidayMakerGrupp2Context();
            List<Accomodation> availableHotels = new();
            var accList = await _context.Accomodations.AsQueryable().Where(c => c.DistanceBeach <= distanceToBeach && c.DistanceDowntown <= distanceToCity).Include(c => c.City).ToListAsync();
            var bookingsInCity = await GetBookingsAsync(date, null, city, _context);
            foreach (var acc in accList)
            {
                int bookedRooms = 0;

                if (bookingsInCity.Contains(acc.Id))
                {
                    foreach (int b in bookingsInCity)
                    {
                        if (b == acc.Id)
                        {
                            bookedRooms++;
                        }
                    }
                    if (bookedRooms < acc.NrOfRooms)
                        availableHotels.Add(acc);
                }
                if (!availableHotels.Contains(acc) && acc.City.Name == city)
                {
                    availableHotels.Add(acc);
                }
            }
          
            return availableHotels;
        }
        public static async Task<IEnumerable<Accomodation>> Search(DateTime arrivalDate, DateTime departureDate, string city)
        {
            using var _context = new HolidayMakerGrupp2Context();
            List<Accomodation> availableHotels = new();
            var accList = await _context.Accomodations.AsAsyncEnumerable().ToListAsync();
            var bookingsInCity = await GetBookingsAsync(arrivalDate, departureDate, city, _context);
            foreach (var acc in accList)
            {
                int bookedRooms = 0;

                if (bookingsInCity.Contains(acc.Id))
                {
                    foreach (int b in bookingsInCity)
                    {
                        if (b == acc.Id)
                        {
                            bookedRooms++;
                        }
                    }
                    if (bookedRooms < acc.NrOfRooms)
                        availableHotels.Add(acc);
                }
                if (!availableHotels.Contains(acc) && acc.City.Name == city)
                {
                    availableHotels.Add(acc);
                }
            }
            return availableHotels;
        }

        public static async Task<IEnumerable<Accomodation>> Search(DateTime arrivalDate, DateTime departureDate, string city, float distanceToBeach)
        {
            using var _context = new HolidayMakerGrupp2Context();
            List<Accomodation> availableHotels = new();
            var accList = await _context.Accomodations.AsQueryable().Where(c => c.DistanceBeach <= distanceToBeach).Include(c => c.City).ToListAsync();
            var bookingsInCity = await GetBookingsAsync(arrivalDate, departureDate, city, _context);
            foreach (var acc in accList)
            {
                int bookedRooms = 0;

                if (bookingsInCity.Contains(acc.Id))
                {
                    foreach (int b in bookingsInCity)
                    {
                        if (b == acc.Id)
                        {
                            bookedRooms++;
                        }
                    }
                    if (bookedRooms < acc.NrOfRooms)
                        availableHotels.Add(acc);
                }
                if (!availableHotels.Contains(acc) && acc.City.Name == city)
                {
                    availableHotels.Add(acc);
                }
            }
            return availableHotels;
        }

        public static async Task<IEnumerable<Accomodation>> SearchDistanceToCity(DateTime arrivalDate, DateTime departureDate, string city, float distanceToCity)
        {
            using var _context = new HolidayMakerGrupp2Context();
            List<Accomodation> availableHotels = new();
            var accList = await _context.Accomodations.AsQueryable().Where(c => c.DistanceDowntown <= distanceToCity).Include(c => c.City).ToListAsync();
            var bookingsInCity = await GetBookingsAsync(arrivalDate, departureDate, city, _context);
            foreach (var acc in accList)
            {
                int bookedRooms = 0;

                if (bookingsInCity.Contains(acc.Id))
                {
                    foreach (int b in bookingsInCity)
                    {
                        if (b == acc.Id)
                        {
                            bookedRooms++;
                        }
                    }
                    if (bookedRooms < acc.NrOfRooms)
                        availableHotels.Add(acc);
                }
                if (!availableHotels.Contains(acc) && acc.City.Name == city)
                {
                    availableHotels.Add(acc);
                }
            }
            return availableHotels;
        }

        public static async Task<IEnumerable<Accomodation>> Search(DateTime arrivalDate, DateTime departureDate, string city, float distanceToBeach, float distanceToCity)
        {
            using var _context = new HolidayMakerGrupp2Context();
            List<Accomodation> availableHotels = new();
            var accList = await _context.Accomodations.AsQueryable().Where(c => c.DistanceBeach <= distanceToBeach && c.DistanceDowntown <= distanceToCity).Include(c => c.City).ToListAsync();
            var bookingsInCity = await GetBookingsAsync(arrivalDate, departureDate, city, _context);
            foreach (var acc in accList)
            {
                int bookedRooms = 0;

                if (bookingsInCity.Contains(acc.Id))
                {
                    foreach (int b in bookingsInCity)
                    {
                        if (b == acc.Id)
                        {
                            bookedRooms++;
                        }
                    }
                    if (bookedRooms < acc.NrOfRooms)
                        availableHotels.Add(acc);
                }
                if (!availableHotels.Contains(acc) && acc.City.Name == city)
                {
                    availableHotels.Add(acc);
                }
            }
            return availableHotels;
        }

        public static async Task<IEnumerable<Accomodation>> Search()
        {
            using HolidayMakerGrupp2Context _context = new();
            return await _context.Accomodations.AsQueryable().ToListAsync();
        }

        private static async Task<IEnumerable<int>> GetBookingsAsync(DateTime arrivalDate, DateTime? departureDate, string city, HolidayMakerGrupp2Context _context)
        {
            if (departureDate == null)
            {
                return await (from b in _context.Bookings.AsQueryable()
                              where (b.Accomodations.City.Name.ToLower() == city.ToLower()) &&
                              (b.ArrivalDate.Date >= arrivalDate.Date) && (b.DepartureDate.Date > arrivalDate.Date)
                              select (b.Accomodations.Id)).ToListAsync();
            }
            else
            {
                return await (from b in _context.Bookings.AsQueryable()
                              where (b.Accomodations.City.Name.ToLower() == city.ToLower()) &&
                              (b.ArrivalDate.Date >= arrivalDate.Date) && (b.DepartureDate.Date > arrivalDate.Date) &&
                              (b.ArrivalDate.Date >= departureDate && b.DepartureDate > departureDate)
                              select (b.Accomodations.Id)).ToListAsync();
            }
        }
    }
}