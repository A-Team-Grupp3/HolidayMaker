using HolidayMakerGrupp2.Models.Database;
using HolidayMakerGrupp2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerGrupp2.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        public BookingsController()
        {

        }

        [HttpGet]
        public async Task<IEnumerable<Booking>> Get(int id)
        {
            if (int.Equals(id, 0))
            {
                return await BookingService.Get();
            }
            else
            {
                return await BookingService.GetById(id);
            }
        }

        [HttpPost]
        public async Task<int> AddBooking(int customerId, DateTime arrival, DateTime departure, int accomodationsId, int transportationsId, int numberOfGuests, int nrKids, bool extraBed, int comfortId, double totPrice, int roomId)
        {
            return await BookingService.CreateBooking(customerId, arrival, departure, accomodationsId, transportationsId, numberOfGuests, nrKids, extraBed, comfortId, totPrice, roomId);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var bookingId = await BookingService.DeleteBooking(id);
            return Ok(bookingId);
        }

        [HttpPut]
        public async Task<int> UpdateBooking(int id, DateTime arrival, DateTime departure, int nrOfGuests, int nrOfKids, bool extrabeds, int comfortId, int transportId, int roomid, int newroomId)
        {
            Booking booking = new Booking()
            {
                ArrivalDate= arrival,
                DepartureDate = departure,
                NrOfGuests = nrOfGuests,
                NrOfKids = nrOfKids,
                ExtraBed = extrabeds,
                ComfortId = comfortId,
                TransportationId = transportId
            };
            return await BookingService.ChangeBooking(id, booking, roomid, newroomId);
        }
    }
}
