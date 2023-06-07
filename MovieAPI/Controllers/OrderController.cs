
using DTOS.DTOS.CardDTOS;

using Microsoft.AspNetCore.Mvc;
using MVCAPP.BLL.Abstract;

using System.Security.Claims;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IShoppingCartService _cartService;
        IMoviesService _moviesService;
        IOrderService _orderService;
        IShoppingCartService _shoppingCartService;
    
     
        public OrderController(IShoppingCartService shoppingCartService, IMoviesService moviesService, IOrderService orderService, IShoppingCartService shoppingCartService1)
        {
            _cartService = shoppingCartService;
            _moviesService = moviesService;
            _orderService = orderService;
            _shoppingCartService = shoppingCartService1;
           
        }
        private int? Id => Convert.ToInt32((User.Identity as ClaimsIdentity)?.FindFirst("Id")?.Value);
        [HttpGet]
        public async Task<IActionResult> Order()
        {
            int id = Convert.ToInt32(Id.Value.ToString());
            var list = await _orderService.GetOrdersByUserIdAsync(id);
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CardToAddDTO dto)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(Id.Value);
                var list = await _cartService.GetShoppingCartItems(id);
                await _orderService.StoreOrderAsync(list, id, dto);
               
                return Ok();
            }
            else { return BadRequest(); }
        }

    }
}
