#nullable disable

namespace HolidayMakerGrupp2.Models.Database
{
    public partial class RoomInBooking
    {
        public int BookingId { get; set; }
        public int RoomId { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual Room Room { get; set; }
    }
}