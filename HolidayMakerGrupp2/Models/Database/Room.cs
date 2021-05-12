using System.Collections.Generic;

#nullable disable

namespace HolidayMakerGrupp2.Models.Database
{
    public partial class Room
    {
        public Room()
        {
            RoomInBookings = new HashSet<RoomInBooking>();
        }

        public int Id { get; set; }
        public double Price { get; set; }
        public int NrOfBeds { get; set; }
        public int AccomodationsId { get; set; }
        public string RoomType { get; set; }

        public virtual Accomodation Accomodations { get; set; }
        public virtual ICollection<RoomInBooking> RoomInBookings { get; set; }
    }
}