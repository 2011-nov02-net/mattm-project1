using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccess
{
    public partial class project0dbContext : DbContext
    {
        public project0dbContext()
        {
        }

        public project0dbContext(DbContextOptions<project0dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LocationStock> LocationStocks { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.FavoriteStoreNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.FavoriteStore)
                    .HasConstraintName("FK_LOCATION_ID");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Inventory");

                entity.HasOne(d => d.Item)
                    .WithMany()
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__ItemI__3493CFA7");

                entity.HasOne(d => d.Store)
                    .WithMany()
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Store__339FAB6E");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Country).HasMaxLength(30);

                entity.Property(e => e.State).HasMaxLength(30);
            });

            modelBuilder.Entity<LocationStock>(entity =>
            {
                entity.ToTable("LocationStock");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationStocks)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LocationS__Locat__43D61337");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.LocationStocks)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LocationS__Produ__44CA3770");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__Customer__395884C4");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__Locat__3D2915A8");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__Order__3C34F16F");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__Produ__3F115E1A");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
