﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Contacts.Infrastructure;
using Ordering.Application.Contacts.Persistence;
using Ordering.Infrastructure.Mail;
using Ordering.Infrastructure.Persistence;
using Ordering.Infrastructure.Repository;

namespace Ordering.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("OrderDB"), sqlServerOptionsAction: sqlOptions =>
            //{
            //    sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null);
            //}));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddTransient<IEmailService, EmailService>();
            return services;
        }
    }
}