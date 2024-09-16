using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    PhoneNumber = "1234567890",
                  
                    CardName = "Mamun",
                    CardNumber = "963852741",
                    CVV = "639",
                    Expiration = "1226",
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
