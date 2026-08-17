using Microsoft.EntityFrameworkCore;
using OrdersDeliveryProj.Models;

namespace OrdersDeliveryProj.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Конфигурация сущности Order
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SenderCity)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SenderAddress)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.RecipientCity)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RecipientAddress)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Weight);

                entity.Property(e => e.PickupDate)
                    .IsRequired();

                entity.Property(e => e.CreatedDate);

                entity.HasIndex(e => e.OrderNumber)
                    .IsUnique();
            });
        }
    }
}
