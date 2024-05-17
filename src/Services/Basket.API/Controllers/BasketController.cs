using Basket.API.Models;
using Basket.API.Repositories;
using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BasketController : BaseController
    {
        IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBasket(string username)
        {
            try
            {
                var basket = await _basketRepository.GetBasket(username);
                if (basket is null)
                {
                    return CustomResult("Load successful.", HttpStatusCode.NotFound);
                }
                return CustomResult("Load successful.", basket, HttpStatusCode.OK);
            }
            catch (Exception exception)
            {
                return CustomResult(exception.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBasket([FromBody] ShoppingCart basket)
        {
            try
            {
                var updatedBasket = await _basketRepository.UpdateBasket(basket);
                return CustomResult("Update successful.", updatedBasket, HttpStatusCode.OK);
            }
            catch (Exception exception)
            {
                return CustomResult(exception.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string username)
        {
            try
            {
                await _basketRepository.DeleteBasket(username);
                return CustomResult("Delete successful.", HttpStatusCode.OK);
            }
            catch (Exception exception)
            {
                return CustomResult(exception.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}
