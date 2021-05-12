using System;
using System.Collections.Generic;

#nullable disable

namespace HolidayMakerGrupp2.Models.Database
{
    public partial class Transportation
    {
        public Transportation()
        {
            Bookings = new HashSet<Booking>();
            Receipts = new HashSet<Receipt>();
        }

        public int Id { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public string Price { get; set; }
        public string TransportType { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
