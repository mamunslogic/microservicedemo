﻿using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Models;
using Ordering.Infrastructure.Persistence;

namespace Ordering.Infrastructure.Repository
{
    public class OrderRepository : CommonRepository<Order>, IOrderRepository
    {
        OrderDbContext _dbContext;

        public OrderRepository(OrderDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUsername(string username)
        {
            var orderList = await _dbContext.Orders.Where(s => s.Username.Equals(username, StringComparison.CurrentCultureIgnoreCase)).ToListAsync();
            return orderList;
        }
    }
}