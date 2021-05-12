using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HolidayMakerGrupp2.Models.Database
{
    public partial class HolidayMakerGrupp2Context : DbContext
    {
        public HolidayMakerGrupp2Context()
        {
        }

        public HolidayMakerGrupp2Context(DbContextOptions<HolidayMakerGrupp2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Accomodation> Accomodations { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Comfort> Comforts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomInBooking> RoomInBookings { get; set; }
        public virtual DbSet<Transportation> Transportations { get; set; }
        public virtual DbSet<Wishlist> Wishlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=HolidayMakerGrupp2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Accomodation>(entity =>
            {
                entity.ToTable("Accomodation");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Accomodations)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accomodations_Cities");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.ArrivalDate).HasColumnType("datetime");

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.DepartureDate).HasColumnType("datetime");

                entity.HasOne(d => d.Accomodations)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.AccomodationsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Accomodations");

                entity.HasOne(d => d.Comfort)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ComfortId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Comfort");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Customer");

                entity.HasOne(d => d.Transportation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.TransportationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Transportation");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Comfort>(entity =>
            {
                entity.ToTable("Comfort");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.GuId)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("GuID");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNr)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.ToTable("Receipt");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TransportationId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receipts_Booking");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receipts_Customer");

                entity.HasOne(d => d.Transportation)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.TransportationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receipts_Transportation");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.Property(e => e.Review1)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Review");

                entity.HasOne(d => d.Accomodations)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.AccomodationsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_Accomodations");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_Customer");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.RoomType)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Accomodations)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.AccomodationsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_Accomodations");
            });

            modelBuilder.Entity<RoomInBooking>(entity =>
            {
                entity.HasKey(e => new { e.BookingId, e.RoomId });

                entity.ToTable("RoomInBooking");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.RoomInBookings)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomInBooking_Booking");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomInBookings)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomInBooking_Room");
            });

            modelBuilder.Entity<Transportation>(entity =>
            {
                entity.ToTable("Transportation");

                entity.Property(e => e.Departure)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TransportType)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.ToTable("Wishlist");

                entity.HasOne(d => d.Accomodations)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.AccomodationsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wishlist_Accomodations");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wishlist_Customer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}