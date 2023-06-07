
using Microsoft.AspNetCore.Mvc;
using MVCAPP.BLL.Abstract;
using MVCAPP.DTOS.ShoppingCartDTOS;
using System.Security.Claims;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        IShoppingCartService _cartService;
        IMoviesService _moviesService;
      
        public ShoppingCartController(IShoppingCartService shoppingCartService, IMoviesService moviesService)
        {
            _cartService = shoppingCartService;
            _moviesService = moviesService;
            
        }
        private int? Id => Convert.ToInt32((User.Identity as ClaimsIdentity)?.FindFirst("Id")?.Value);
        [HttpGet]
        public async Task<IActionResult> ShoppingCart()
        {
            int id = Convert.ToInt32(Id.Value.ToString());
            var response = await _cartService.GetShoppingCartItems(id);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddItemToShoppingCart([FromBody] ShoppingCartToAddDTO dto)
        {
            
            int Userid = Convert.ToInt32(Id.Value.ToString());
           
                await _cartService.AddItemToCart(dto.MovieId, Userid);
         
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveItemFromShoppingCart([FromRoute] int movieId)
        {

            int Userid = Convert.ToInt32(Id.Value.ToString());
            await _cartService.DeleteItemFromCart(movieId, Userid);
            
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> ClearShoppingCart()
        {
            int Userid = Convert.ToInt32(Id.Value.ToString());
            await _cartService.ClearShoppingCartAsync(Userid);
            return Ok();
        }
    }
}
