using BLL.BLL.Abstract;
using DAL;
using DTOS.DTOS.CommentDTOS;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCAPP.DTOS.DTOS;
using System.Security.Claims;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        ICommentService _service;
     
        public CommentController(ICommentService service)
        {
            _service = service;
               

        }
        private int? Id => Convert.ToInt32((User.Identity as ClaimsIdentity)?.FindFirst("Id")?.Value);
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CommentToAddDTO dto)
        {
            int id = Convert.ToInt32(Id.Value.ToString());
            if (ModelState.IsValid)
            {
                await _service.AddAsync(dto, id);
                return Ok();


            }
            return BadRequest();


        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] CommentToUpdateDTO dto)
        {
            int usrid = Convert.ToInt32(Id.Value.ToString());
            if (_service.HasPermissionAsync(usrid, id))
            { 
                await _service.UpdateAsync(id, dto);
            return Ok();

        }
            return Forbid();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            int usrid = Convert.ToInt32(Id.Value.ToString());

            if ( _service.HasPermissionAsync(usrid, id))
            {
                await _service.DeleteAsync(id);


                return Ok();
            }

            return Forbid();

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var list = _service.GetAsync();
            return Ok(await list);
        }
    }
}
