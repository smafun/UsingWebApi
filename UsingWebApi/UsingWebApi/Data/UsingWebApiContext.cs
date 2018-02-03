using UsingWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace UsingWebApi.Data
{
    public class UsingWebApiContext : DbContext
    {
        public UsingWebApiContext (DbContextOptions<UsingWebApiContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Customer>().ToTable("Customer");
        }
    }
}
