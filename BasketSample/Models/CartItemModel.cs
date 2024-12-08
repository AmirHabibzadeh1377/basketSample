namespace BasketSample.Models
{
    public class CartItemModel
    {
        public ProductModel Product { get; set; }  = new();
        public int Quantity { get; set; }
        public decimal TotalPrice => Product.Price * Quantity;
    }
}