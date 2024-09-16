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
                    CreatedBy ="Test",
                    CreatedDate = DateTime.Now,

                    Id = 1,
                    Username = "mamunslogic@gmail.com",
                    FirstName = "Abdur Rashid",
                    LastName = "Mamun",
                    EmailAddress = "mamunslogic@gmail.com",
                    Address = "Dhaka",
                    City = "Dhaka",
                    State = "Bangladesh",
                    ZipCode="1216",
                    TotalPrice = 100,
                    PhoneNumber = "01712371173",
                    CardName = "Mamun",
                    CardNumber = "963852741",
                    CVV = "639",
                    Expiration = DateTime.Now.AddYears(3).ToShortDateString(),
                    PaymentMethod = 1,

                }
                //new Order
                //{
                //    Id = 2,
                //    Username = "mamunslogic@yahoo.com",
                //    FirstName = "Abdur Rashid",
                //    LastName = "Mamun",
                //    EmailAddress = "mamunslogic@gmail.com",
                //    Address = "Dhaka",
                //    City = "Dhaka",
                //    State = "Bangladesh",
                //    TotalPrice = 100,
                //}
                );
        }
    }
}
