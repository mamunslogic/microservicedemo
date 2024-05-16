using Catelog.API.Models;
using MongoRepo.Interfaces.Manager;

namespace Catalog.API.Interfaces.Manager
{
    public interface IProductManager : ICommonManager<Product>
    {
        public List<Product> GetByCatagory(string catagory);
    }
}
