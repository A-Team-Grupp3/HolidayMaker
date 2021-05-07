using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayMakerGrupp2.Models.Database;

namespace HolidayMakerGrupp2.Services
{
    public static class BookingService
    {
        private static HolidayMakerGrupp2Context ctx = new HolidayMakerGrupp2Context();

        //public BookingService()
        //{

        //}

        public static int CreateBooking(int customerId, DateTime arrival, DateTime departure, int accomodationsId, int transportationsId, int numberOfGuests, int nrKids, bool extraBed, int comfortId, double totPrice)
        {

            var createdOrder = ctx.Bookings.Add(new Booking
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
            return createdOrder.Entity.Id;
        }

        public static void ChangeBooking(int id, Booking booking)
        {
            var oldBooking = ctx.Bookings.Find(id);

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
            ctx.SaveChanges();
        }

    }
}
