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
                    Id = 1,
                    Username = "mamunslogic@gmail.com",
                    FirstName = "Abdur Rashid",
                    LastName = "Mamun",
                    EmailAddress = "mamunslogic@gmail.com",
                    Address = "Dhaka",
                    City = "Dhaka",
                    State = "Bangladesh",
                    TotalPrice = 100,
                },
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
