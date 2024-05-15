using Catalog.API.Interfaces.Repository;
using Catelog.API.Context;
using Catelog.API.Models;
using MongoRepo.Context;
using MongoRepo.Repository;

namespace Catalog.API.Repository
{
    public class ProductRepository : CommonRepository<Product>, IProductRepository
    {
        public ProductRepository() : base(new CatalogDbContext())
        {
        }
    }
}
