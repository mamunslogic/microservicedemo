using Catalog.API.Interfaces.Manager;
using Catelog.API.Models;
using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Net;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatalogController : BaseController
    {
        IProductManager _productManager;

        public CatalogController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        [ResponseCache(Duration = 10)]
        public IActionResult GetProducts()
        {
            try
            {
                var products = _productManager.GetAll();
                return CustomResult("Data loaded successfully.", products);
            }
            catch (Exception exception)
            {
                return CustomResult(exception.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        [ResponseCache(Duration = 30)]
        public IActionResult GetByCatagory(string catagory)
        {
            try
            {
                var products = _productManager.GetByCatagory(catagory);
                return CustomResult("Data loaded successfully.", products);
            }
            catch (Exception exception)
            {
                return CustomResult(exception.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public IActionResult GetById(string id)
        {
            try
            {
                var products = _productManager.GetById(id);
                if (products == null)
                {
                    return CustomResult("Data not found.", products, HttpStatusCode.NotFound);
                }
                return CustomResult("Data loaded successfully.", products);
            }
            catch (Exception exception)
            {
                return CustomResult(exception.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
                product.Id = ObjectId.GenerateNewId().ToString();
                bool isSaved = _productManager.Add(product);
                if (isSaved)
                {
                    return CustomResult("Save successful.", product, HttpStatusCode.Created);
                }
                return CustomResult("Save failed.", product, HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {
                return CustomResult(exception.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            try
            {
                if (string.IsNullOrEmpty(product.Id))
                {
                    return CustomResult("Data not found.", HttpStatusCode.NotFound);
                }

                bool isUpdated = _productManager.Update(product.Id, product);
                if (isUpdated)
                {
                    return CustomResult("Update successful.", product, HttpStatusCode.OK);
                }
                return CustomResult("Update failed.", product, HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {
                return CustomResult(exception.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public IActionResult DeleteProduct(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return CustomResult("Data not found.", HttpStatusCode.NotFound);
                }

                bool isDeleted = _productManager.Delete(id);
                if (isDeleted)
                {
                    return CustomResult("Delete successful.", HttpStatusCode.OK);
                }
                return CustomResult("Delete failed.", HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {
                return CustomResult(exception.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}
