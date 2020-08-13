using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using panierAchat.Models;

namespace panierAchat.Data
{
    public class panierAchatContext : DbContext
    {
        public panierAchatContext (DbContextOptions<panierAchatContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<Orderline> Orderline { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ShippingOrder> ShippingOrder { get; set; }
        public DbSet<Supplier> Supplier { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<Credentials>().ToTable("Credentials");
            modelBuilder.Entity<Orderline>().ToTable("Orderline");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ShippingOrder>().ToTable("ShippingOrder");
            modelBuilder.Entity<Supplier>().ToTable("Supplier");
        }
    }
}
