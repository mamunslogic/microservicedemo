using CoreApiResponse;
using Discount.API.Models;
using Discount.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Discount.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiscountController : BaseController
    {
        ICouponRepository _couponRepository;

        public DiscountController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDiscount(string productId)
        {
            try
            {
                var discount = await _couponRepository.GetDiscount(productId);
                if (discount is null)
                {
                    return CustomResult("Load successful.", HttpStatusCode.NotFound);
                }
                return CustomResult("Load successful.", discount, HttpStatusCode.OK);
            }
            catch (Exception exception)
            {
                return CustomResult(exception.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateDiscount([FromBody] Coupon coupon)
        {
            try
            {
                var isCreated = await _couponRepository.CreateDiscount(coupon);
                if (isCreated)
                {
                    return CustomResult("Save successful.", coupon, HttpStatusCode.OK);
                }
                return CustomResult("Save failed.", HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {
                return CustomResult(exception.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateDiscount([FromBody] Coupon coupon)
        {
            try
            {
                var isUpdated = await _couponRepository.UpdateDiscount(coupon);
                if (isUpdated)
                {
                    return CustomResult("Update successful.", coupon, HttpStatusCode.OK);
                }
                return CustomResult("Update failed.", HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {
                return CustomResult(exception.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteDiscount(string productId)
        {
            try
            {
                var isDeleted = await _couponRepository.DeleteDiscount(productId);
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
