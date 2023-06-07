using BLL.BLL.Abstract;
using DTOS.DTOS.FavoriteDTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        IFavoriteService _service;
        public FavoriteController(IFavoriteService service)
        {
            _service = service;

        }
        private int? Id => Convert.ToInt32((User.Identity as ClaimsIdentity)?.FindFirst("Id")?.Value);
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FavoriteToAddDTO dto)
        {
            int id = Convert.ToInt32(Id.Value.ToString());
            if (ModelState.IsValid)
            {
                await _service.AddAsync(dto, id);
                return Ok();


            }
            return BadRequest();


        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int id = Convert.ToInt32(Id.Value.ToString());

            var list = _service.GetAsync(id);
            return Ok(list);
        }
    }
}
