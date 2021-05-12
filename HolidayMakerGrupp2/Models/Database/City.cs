using System.Collections.Generic;

#nullable disable

namespace HolidayMakerGrupp2.Models.Database
{
    public partial class City
    {
        public City()
        {
            Accomodations = new HashSet<Accomodation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Accomodation> Accomodations { get; set; }
    }
}