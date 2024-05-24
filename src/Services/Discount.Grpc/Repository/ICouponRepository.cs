using Discount.Grpc.Models;

namespace Discount.Grpc.Repository
{
    public interface ICouponRepository
    {
        Task<bool> CreateDiscount(Coupon coupon);
        Task<Coupon> GetDiscount(string productId);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool> DeleteDiscount(string productId);
    }
}
