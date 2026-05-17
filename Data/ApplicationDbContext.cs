using Microsoft.EntityFrameworkCore;
using ASPCRUDAssignment.Models;

namespace ASPCRUDAssignment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    CustomerName = "Bashiir Abshir Ali",
                    ProductName = "Wireless Headphones",
                    Quantity = 2,
                    Price = 79.99m,
                    OrderDate = new DateTime(2025, 1, 10)
                },
                new Order
                {
                    Id = 2,
                    CustomerName = "Maaido Abdi Said",
                    ProductName = "Mechanical Keyboard",
                    Quantity = 1,
                    Price = 149.95m,
                    OrderDate = new DateTime(2025, 1, 15)
                },
                new Order
                {
                    Id = 3,
                    CustomerName = "Aniso Farah Jama",
                    ProductName = "USB-C Hub",
                    Quantity = 3,
                    Price = 34.50m,
                    OrderDate = new DateTime(2025, 1, 20)
                },
                new Order
                {
                    Id = 4,
                    CustomerName = "Mohamed Ali Nur",
                    ProductName = "Laptop Stand",
                    Quantity = 1,
                    Price = 59.99m,
                    OrderDate = new DateTime(2025, 2, 5)
                },
                new Order
                {
                    Id = 5,
                    CustomerName = "Abdirahman Abdi Farah",
                    ProductName = "Webcam HD",
                    Quantity = 2,
                    Price = 89.00m,
                    OrderDate = new DateTime(2025, 2, 10)
                }
            );
        }
    }
}
