using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Models;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasData(
                new Order
                {
                    Id = 1,
                    Username = "mamunslogic@gmail.com",
                    FirstName = "Abdur Rashid",
                    LastName = "Mamun",
                    EmailAddress = "mamunslogic@gmail.com",
                    Address = "Dhaka",
                    City = "Dhaka",
                    State = "Bangladesh",
                    ZipCode = "1212",
                    TotalPrice = 100,
                    CardName = "Test",
                    CardNumber = "Test",
                    CreatedBy = "Test",
                    CreatedDate = DateTime.Now,
                    CVV = "Test",
                    Expiration = DateTime.Now.AddYears(3).ToShortDateString(),
                    PaymentMethod = 1,
                    PhoneNumber = "01712371173",
                });
        }
    }
}
