using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AmazonAPI.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Identity
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(r => new { r.UserId, r.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
            //Relations
            modelBuilder.Entity<Store>().HasOne(s => s.Owner).WithMany(u => u.Stores).HasForeignKey(s => s.OwnerId);
            modelBuilder.Entity<Store>().HasMany(s => s.Products).WithOne(p => p.Store).HasForeignKey(p => p.StoreId);

            modelBuilder.Entity<Product>().HasMany(p => p.Photos).WithOne(p => p.Product).HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<Product>().HasMany(p => p.Tags).WithOne(p => p.Product).HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<CartItem>().HasOne(ci => ci.Customer).WithMany(c => c.CartItems).HasForeignKey(ci => ci.CustomerId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CartItem>().HasOne(ci => ci.Product).WithMany(p => p.Carts).HasForeignKey(ci => ci.ProductId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WishListItem>().HasOne(wl => wl.Customer).WithMany(c => c.WishListItems).HasForeignKey(wl => wl.CustomerId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<WishListItem>().HasOne(wl => wl.Product).WithMany(p => p.WishLists).HasForeignKey(wl => wl.ProductId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderDetail>().HasKey(od => new { od.OrderId, od.ProductId });
            modelBuilder.Entity<OrderDetail>().HasOne(od => od.Order).WithMany(o => o.OrderDetails).HasForeignKey(od => od.OrderId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderDetail>().HasOne(od => od.Product).WithMany(p => p.Orders).HasForeignKey(od => od.ProductId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>().HasOne(r => r.Customer).WithMany(c => c.Reviews).HasForeignKey(r => r.CustomerId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Review>().HasOne(r => r.Product).WithMany(p => p.Reviews).HasForeignKey(r => r.ProductId);

            modelBuilder.Entity<Offer>().HasMany(o => o.Products).WithOne(p => p.Offer).HasForeignKey(p => p.OfferId);
        }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<WishListItem> WishListItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Offer> Offers { get; set; }

    }
}