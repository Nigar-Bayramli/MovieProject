using BLL.BLL.Abstract;
using DTOS.DTOS.RatingDTOS;

using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        IRatingService _service;
        public RatingController(IRatingService service)
        {
            _service = service;
            
        }
        private int? Id => Convert.ToInt32((User.Identity as ClaimsIdentity)?.FindFirst("Id")?.Value);
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RatingToAddDTO dto)
        {
            int id = Convert.ToInt32(Id.Value.ToString());
            if(ModelState.IsValid)
            {
                await _service.AddAsync(dto, id);
                return Ok();


            }
            return BadRequest();
            
            
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           
            var list = _service.GetAsync();
            return Ok(list);
        }
        [HttpGet("Ascending")]
        public async Task<IActionResult> GetAscendingOrder()
        {

            var list = _service.GetMoviesAscending();
            return Ok(list);
        }
    }
}
