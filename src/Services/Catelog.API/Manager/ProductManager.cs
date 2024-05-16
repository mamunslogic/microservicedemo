﻿using Catalog.API.Interfaces.Manager;
using Catalog.API.Repository;
using Catelog.API.Models;
using MongoRepo.Manager;
using MongoRepo.Repository;

namespace Catalog.API.Manager
{
    public class ProductManager : CommonManager<Product>, IProductManager
    {
        public ProductManager() : base(new ProductRepository())
        {
        }

        public List<Product> GetByCatagory(string catagory)
        {
            return GetAll(c => c.Category == catagory).ToList();
        }
    }
}
