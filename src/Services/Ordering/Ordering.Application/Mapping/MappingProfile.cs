﻿using AutoMapper;
using Ordering.Application.Features.Orders.Queries.GetOrdersByUsername;
using Ordering.Domain.Models;

namespace Ordering.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderViewModel>().ReverseMap();
        }
    }
}
