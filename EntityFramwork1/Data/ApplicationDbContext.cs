using EntityFramwork1.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace EntityFramwork1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=EcommerceDB;Trusted_Connection=True; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //composite PrimaryKey
            modelBuilder.Entity<OrderDetails>().HasKey(od => new { od.OrderId, od.ProductId });
            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(c => c.products)
                                          .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Order>().HasOne(o => o.Customer)
                                        .WithMany(c => c.Orders)
                                        .HasForeignKey(o => o.CustomerId);
            modelBuilder.Entity<OrderDetails>().HasOne(o => o.Order)
                                               .WithMany(od => od.OrderDetails)
                                               .HasForeignKey(o => o.OrderId);
            modelBuilder.Entity<OrderDetails>().HasOne(p => p.Product)
                                               .WithMany(od => od.OrderDetails)
                                               .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<Product>().Property(p => p.Price)
                                          .HasPrecision(18, 2);
                                               
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
