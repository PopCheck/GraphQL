using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MyShop.API.Models;

namespace MyShop.API.Context
{
    public partial class PostgresDbContext : DbContext
    {
        public PostgresDbContext()
        {
        }

        public PostgresDbContext(DbContextOptions<PostgresDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Orderdetails> Orderdetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("host=localhost;database=graphqlpostgres;username=postgres;password=P@ssword1; port=5432;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orderdetails>(entity =>
            {
                entity.HasKey(e => new { e.Orderid, e.Productid })
                    .HasName("orderdetails_pkey");

                entity.ToTable("orderdetails");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderdetails_orderid_fkey");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.Orderid)
                    .HasName("orders_pkey");

                entity.ToTable("orders");

                entity.Property(e => e.Orderid)
                    .HasColumnName("orderid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Orderdate)
                    .HasColumnName("orderdate")
                    .HasColumnType("date")
                    .HasDefaultValueSql("CURRENT_DATE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
