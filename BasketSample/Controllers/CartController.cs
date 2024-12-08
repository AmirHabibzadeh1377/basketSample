using BasketSample.CartService;
using BasketSample.Models;

using Microsoft.AspNetCore.Mvc;

namespace BasketSample.Controllers
{
    public class CartController : Controller
    {
        #region Fields

        private readonly ICartService _cartService;

        #endregion

        #region Ctor

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        #endregion

        [HttpPost]
        public IActionResult AddToBasket([FromBody] ProductModel product)
        {
            _cartService.AddToCart(product, 1);
            return Ok("Add To Cart Items");
        }

        [HttpPut]
        public IActionResult UpdateCartItem(int productId, [FromBody] int quantity)
        {
            _cartService.UpdateCart(productId, quantity);
            return Ok();
        }

        [HttpDelete]
        public IActionResult RemoveCartItem(int productId) 
        {
            _cartService.RemoveFromCart(productId);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetCartItems()
        {
            return Ok(_cartService.GetAll());
        }

        [HttpGet]
        public IActionResult GetTotalPrice()
        {
            var totalPrice = _cartService.GetTotalPrice();
            return Ok(totalPrice);  
        }

    }
}