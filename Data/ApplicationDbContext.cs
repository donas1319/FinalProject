using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieTicketReservation.Models;

namespace MovieTicketReservation.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Category> categories { get; set; }
        public DbSet<Movies> movies { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Movies>()
                .HasOne(p => p.category)
                .WithMany(c => c.movies)
                .HasForeignKey(p => p.CategoryId)
                .HasConstraintName("FK_Movies_CategoryID");

            //Product and OrderDetail
            builder.Entity<OrderDetail>()
                   .HasOne(p => p.movies)
                   .WithMany(c => c.OrderDetails)
                   .HasForeignKey(p => p.ProductId)
                   .HasConstraintName("FK_OrderDetails_ProductId");
            //Product and Cart
            builder.Entity<Cart>()
                   .HasOne(p => p.movies)
                   .WithMany(c => c.Carts)
                   .HasForeignKey(p => p.ProductId)
                   .HasConstraintName("FK_Carts_ProductId");
            //OrderDetail and Order
            builder.Entity<OrderDetail>()
                   .HasOne(p => p.Order)
                   .WithMany(c => c.OrderDetails)
                   .HasForeignKey(p => p.OrderId)
                   .HasConstraintName("FK_OrderDetails_OrderId");
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    }
}
