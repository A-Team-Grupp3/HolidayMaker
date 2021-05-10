using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayMakerGrupp2.Models.Database;

namespace HolidayMakerGrupp2.Services
{
    public static class BookingService
    {
        

        public static async Task<IEnumerable<Booking>> Get()
        {
            using var ctx = new HolidayMakerGrupp2Context();
            

                return await ctx.Bookings.AsAsyncEnumerable().ToListAsync();
            

        }
        public static async Task<IEnumerable<Booking>> GetById(int id)
        {
            using var ctx = new HolidayMakerGrupp2Context();
            


                var bookings = await ctx.Bookings.AsAsyncEnumerable().Where(c => c.Id == id).ToListAsync();

                return bookings;
            
        }

        public static async Task<Booking> DeleteBooking(int id)
        {
            using var ctx = new HolidayMakerGrupp2Context();
            


                var bookingToDelete = await ctx.Bookings.AsAsyncEnumerable().Where(c => c.Id == id).SingleAsync();
                ctx.Bookings.Remove(bookingToDelete);
                ctx.SaveChanges();
                return bookingToDelete;
            
        }

        public static async Task<int> CreateBooking(int customerId, DateTime arrival, DateTime departure, int accomodationsId, int transportationsId, int numberOfGuests, int nrKids, bool extraBed, int comfortId, double totPrice, int roomId)
        {
            using var ctx = new HolidayMakerGrupp2Context();
            


                var createdOrder = await ctx.Bookings.AddAsync(new Booking
                {
                    CustomerId = customerId,
                    BookingDate = DateTime.Now,
                    DepartureDate = departure,
                    ArrivalDate = arrival,
                    TransportationId = transportationsId,
                    AccomodationsId = accomodationsId,
                    NrOfGuests = numberOfGuests,
                    NrOfKids = nrKids,
                    ExtraBed = extraBed,
                    ComfortId = comfortId,
                    TotalPrice = totPrice
                });
                ctx.SaveChanges();
                var roomBooking = ctx.RoomInBookings.AddAsync(new RoomInBooking { BookingId = createdOrder.Entity.Id, RoomId = roomId});
                ctx.SaveChanges();
               
                return createdOrder.Entity.Id;
            
        }

        public static async Task<int> ChangeBooking(int id, Booking booking, int roomId, int newRoomId)
        {
            using var ctx = new HolidayMakerGrupp2Context();
            


                var oldBooking = await ctx.Bookings.FindAsync(id);
                var oldroomInBooking = await ctx.RoomInBookings.FindAsync(id, roomId);

                if (oldBooking.ArrivalDate != booking.ArrivalDate)
                {
                    oldBooking.ArrivalDate = booking.ArrivalDate;
                }
                if (oldBooking.DepartureDate != booking.DepartureDate)
                {
                    oldBooking.DepartureDate = booking.DepartureDate;
                }
                if (oldBooking.NrOfKids != booking.NrOfKids)
                {
                    oldBooking.NrOfKids = booking.NrOfKids;
                }
                if (oldBooking.NrOfGuests != booking.NrOfGuests)
                {
                    oldBooking.NrOfGuests = booking.NrOfGuests;
                }
                if (oldBooking.ExtraBed != booking.ExtraBed)
                {
                    oldBooking.ExtraBed = booking.ExtraBed;
                }
                if (oldBooking.ComfortId != booking.ComfortId)
                {
                    oldBooking.ComfortId = booking.ComfortId;
                }
                if (oldBooking.TransportationId != booking.TransportationId)
                {
                    oldBooking.TransportationId = booking.TransportationId;
                }
                if (oldBooking.Id == oldroomInBooking.BookingId && oldroomInBooking.RoomId != newRoomId)
                {
                oldroomInBooking = new RoomInBooking() { BookingId = oldBooking.Id, RoomId = newRoomId };
                }
                ctx.SaveChanges();
                return oldBooking.Id;
            
        }

    }
}

