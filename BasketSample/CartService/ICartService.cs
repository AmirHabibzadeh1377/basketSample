using BasketSample.Models;

namespace BasketSample.CartService
{
    public interface ICartService
    {
        void AddToCart(ProductModel product, int quantity);
        void UpdateCart(int productId, int quantity);
        void RemoveFromCart(int productId);
        decimal GetTotalPrice();
        void ClearCart();
        List<CartItemModel> GetAll();
    }
}