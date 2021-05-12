using System;
using System.Collections.Generic;

#nullable disable

namespace HolidayMakerGrupp2.Models.Database
{
    public partial class Booking
    {
        public Booking()
        {
            Receipts = new HashSet<Receipt>();
            RoomInBookings = new HashSet<RoomInBooking>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public int AccomodationsId { get; set; }
        public int TransportationId { get; set; }
        public int NrOfGuests { get; set; }
        public int NrOfKids { get; set; }
        public bool ExtraBed { get; set; }
        public int ComfortId { get; set; }
        public double TotalPrice { get; set; }

        public virtual Accomodation Accomodations { get; set; }
        public virtual Comfort Comfort { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Transportation Transportation { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
        public virtual ICollection<RoomInBooking> RoomInBookings { get; set; }
    }
}