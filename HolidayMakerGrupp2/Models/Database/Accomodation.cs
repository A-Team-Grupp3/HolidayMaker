using System;
using System.Collections.Generic;

#nullable disable

namespace HolidayMakerGrupp2.Models.Database
{
    public partial class Accomodation
    {
        public Accomodation()
        {
            Bookings = new HashSet<Booking>();
            Reviews = new HashSet<Review>();
            Rooms = new HashSet<Room>();
            Wishlists = new HashSet<Wishlist>();
        }

        public int Id { get; set; }
        public int CityId { get; set; }
        public int NrOfRooms { get; set; }
        public bool Pool { get; set; }
        public bool NightEntertainment { get; set; }
        public bool KidsClub { get; set; }
        public bool Restaurants { get; set; }
        public double DistanceBeach { get; set; }
        public double DistanceDowntown { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}
