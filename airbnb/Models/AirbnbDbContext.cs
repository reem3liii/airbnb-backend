using Microsoft.EntityFrameworkCore;

namespace airbnb.Models
{
    public class AirbnbDbContext: DbContext
    {
        public AirbnbDbContext()
        {

        }
        public AirbnbDbContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rent>(a =>
            {
                a.HasKey(a => new { a.CustomerId, a.PlaceId, a.ContractId });
            });
            modelBuilder.Entity<Customer_Phone>(a =>
            {
                a.HasKey(a => new { a.CustomerId, a.PhoneNumber});
            });
            modelBuilder.Entity<Owner_Phone>(a =>
            {
                a.HasKey(a => new { a.OwnerId, a.PhoneNumber });
            });
            modelBuilder.Entity<Place_Image>(a =>
            {
                a.HasKey(a => new { a.PlaceId, a.ImageName });
            });
            modelBuilder.Entity<Place_Service>(a =>
            {
                a.HasKey(a => new { a.PlaceId, a.Service });
            });
        }
    }
}
