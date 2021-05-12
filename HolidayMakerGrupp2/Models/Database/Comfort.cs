using System.Collections.Generic;

#nullable disable

namespace HolidayMakerGrupp2.Models.Database
{
    public partial class Comfort
    {
        public Comfort()
        {
            Bookings = new HashSet<Booking>();
        }

        public string Name { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}