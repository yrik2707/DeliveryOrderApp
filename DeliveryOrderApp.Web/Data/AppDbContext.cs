using Microsoft.EntityFrameworkCore;
using DeliveryOrderApp.Web.Models;

namespace DeliveryOrderApp.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.SenderCity).IsRequired().HasMaxLength(100);
                entity.Property(e => e.SenderAddress).IsRequired().HasMaxLength(300);
                entity.Property(e => e.ReceiverCity).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ReceiverAddress).IsRequired().HasMaxLength(300);
                entity.Property(e => e.Weight).HasColumnType("decimal(10,2)");
                entity.Property(e => e.PickupDate).IsRequired().HasColumnType("timestamp without time zone");
            });
        }
    }
}