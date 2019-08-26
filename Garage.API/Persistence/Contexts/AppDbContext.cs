using Garage.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Garage.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>().ToTable("customers");
            builder.Entity<Customer>().HasKey(p => p.Id);
            builder.Entity<Customer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Customer>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Customer>().Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Entity<Customer>().Property(p => p.MobileNumber).IsRequired().HasMaxLength(10);
            builder.Entity<Customer>().HasMany(p => p.Orders).WithOne(p => p.Customer).HasForeignKey(p => p.CustomerId);

            builder.Entity<Customer>().HasData
                (
                    new Customer { Id = 100, Name = "Salman", Email = "salman@gmail.com", MobileNumber = "9999999999" },
                    new Customer { Id = 101, Name = "Suresh", Email = "suresh@gmail.com", MobileNumber = "8888888888" },
                    new Customer { Id = 102, Name = "Mahesh", Email = "mahesh@gmail.com", MobileNumber = "7777777777" }

                );

            builder.Entity<Order>().ToTable("orders");
            builder.Entity<Order>().HasKey(p => p.Id);
            builder.Entity<Order>().Property(P => P.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Order>().Property(P => P.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Order>().Property(p => p.Price).IsRequired();
            //builder.Entity<Order>().

            builder.Entity<Order>().HasData
                (
                    new Order
                    {
                        Id = 201,
                        Name = "Soap",
                        Price = 120,
                        CustomerId = 101
                    },
                    new Order
                    {
                        Id = 202,
                        Name = "Spoon",
                        Price = 10,
                        CustomerId = 101
                    },
                    new Order
                    {
                        Id = 203,
                        Name = "Sindoor",
                        Price = 102,
                        CustomerId = 101
                    },
                     new Order
                     {
                         Id = 204,
                         Name = "Nirma",
                         Price = 88.50,
                         CustomerId = 100
                     },
                     new Order
                     {
                         Id = 205,
                         Name = "Neem",
                         Price = 81.50,
                         CustomerId = 100
                     },
                     new Order
                     {
                         Id = 206,
                         Name = "Neem",
                         Price = 81.50,
                         CustomerId = 102
                     }

                );

            builder.Entity<Discount>().ToTable("discounts");
            builder.Entity<Discount>().HasKey(p => p.Id);
            builder.Entity<Discount>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Discount>().Property(p => p.CustomerId).IsRequired();
            builder.Entity<Discount>().Property(p => p.OrderId).IsRequired();
            builder.Entity<Discount>().Property(p => p.DiscountValue).IsRequired();
            //builder.Entity<Discount>().HasOne(p=>p.Customer).WithOne(p=>p.)
            builder.Entity<Discount>().HasData
                (
                    new Discount { Id = 301, CustomerId = 101, OrderId = 203, DiscountValue = 5 }
                );
        }
    }
}
