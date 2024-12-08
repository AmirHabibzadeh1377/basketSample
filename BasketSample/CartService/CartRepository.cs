
using BasketSample.Models;

namespace BasketSample.CartService
{
    public class CartRepository : ICartService
    {
        #region Fields

        private readonly List<CartItemModel> _cartItems = new();

        #endregion

        public void AddToCart(ProductModel product, int quantity)
        {
            var existitngCartItem = _cartItems.FirstOrDefault(x => x.Product.Id == product.Id);
            if (existitngCartItem != null)
            {
                existitngCartItem.Quantity += quantity;
            }
            else
            {
                _cartItems.Add(new CartItemModel { Quantity = quantity, Product = product });
            }
        }

        public void ClearCart()
        {
            _cartItems.Clear();
        }

        public decimal GetTotalPrice()
        {
            return _cartItems.Sum(x => x.TotalPrice);
        }

        public void RemoveFromCart(int productId)
        {
            var cartItem = _cartItems.FirstOrDefault(item => item.Product.Id == productId);
            if (cartItem != null)
            {
                _cartItems.Remove(cartItem);
            }
        }

        public void UpdateCart(int productId, int quantity)
        {
            var cartItem = _cartItems.FirstOrDefault(x=>x.Product.Id == productId);
            if (cartItem is not null)
            {
                if(quantity <= 0)
                {
                    _cartItems.Remove(cartItem);
                }
                else
                {
                    cartItem.Quantity = quantity;
                }
            }
        }

        public List<CartItemModel> GetAll()
        {
            return _cartItems;
        }
    }
}