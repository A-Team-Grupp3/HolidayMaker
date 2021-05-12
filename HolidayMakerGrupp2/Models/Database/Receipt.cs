#nullable disable

namespace HolidayMakerGrupp2.Models.Database
{
    public partial class Receipt
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int TransportationId { get; set; }
        public int CustomerId { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Transportation Transportation { get; set; }
    }
}