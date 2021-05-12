#nullable disable

namespace HolidayMakerGrupp2.Models.Database
{
    public partial class Review
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AccomodationsId { get; set; }
        public string Review1 { get; set; }

        public virtual Accomodation Accomodations { get; set; }
        public virtual Customer Customer { get; set; }
    }
}