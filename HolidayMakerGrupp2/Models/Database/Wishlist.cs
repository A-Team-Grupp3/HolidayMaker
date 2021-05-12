#nullable disable

namespace HolidayMakerGrupp2.Models.Database
{
    public partial class Wishlist
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AccomodationsId { get; set; }

        public virtual Accomodation Accomodations { get; set; }
        public virtual Customer Customer { get; set; }
    }
}