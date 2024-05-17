namespace Basket.API.Models
{
    public class ShoppingCart
    {
        public ShoppingCart(string username)
        {
            Username = username;
        }

        public ShoppingCart()
        {

        }

        public string Username { get; set; }
        public List<ShoopingCartItem> Items { get; set; } = [];
        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in Items)
                {
                    totalPrice += item.Price;
                }
                return totalPrice;
            }
        }
    }
}
