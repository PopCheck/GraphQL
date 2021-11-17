using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MyShop.API.Models;

namespace MyShop.API.Context
{
    public partial class SqlDbContext : DbContext
    {
        public SqlDbContext()
        {
        }

        public SqlDbContext(DbContextOptions<SqlDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=localhost;database=graphqlsqlserver;uid=sa;pwd=P@ssword1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Companyname)
                    .IsRequired()
                    .HasColumnName("companyname")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Productname)
                    .IsRequired()
                    .HasColumnName("productname")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.Property(e => e.Unitprice).HasColumnName("unitprice");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
