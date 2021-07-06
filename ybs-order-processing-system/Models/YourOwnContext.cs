using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace ybs_order_processing_system.Models
{
    public partial class YourOwnContext : DbContext
    {
        public YourOwnContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public YourOwnContext(DbContextOptions<YourOwnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Buyer> Buyers { get; set; }
        
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        private readonly IConfiguration _configuration;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.Property(e => e.BuyerId).ValueGeneratedNever();

                entity.Property(e => e.BuyerMail).IsUnicode(false);

                entity.Property(e => e.BuyerName).IsUnicode(false);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.CategoryName).IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).ValueGeneratedOnAdd();

                entity.Property(e => e.BuyerAddress).IsUnicode(false);

                entity.Property(e => e.BuyerPhoneNum).IsUnicode(false);

                entity.Property(e => e.OrderPaymentType).IsUnicode(false);

                entity.Property(e => e.OrderStatus).IsUnicode(false);

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERS_BUYER");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERS_PRODUCT");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERS_SELLER");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.ProductName).IsUnicode(false);

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_CATEGORY");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.Property(e => e.SellerId).ValueGeneratedNever();

                entity.Property(e => e.SellerAddress).IsUnicode(false);

                entity.Property(e => e.SellerMail).IsUnicode(false);

                entity.Property(e => e.SellerName).IsUnicode(false);

                entity.Property(e => e.SellerPhoneNum).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Username).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Role).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
