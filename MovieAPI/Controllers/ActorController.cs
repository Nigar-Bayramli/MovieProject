using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCAPP.BLL.Abstract;
using MVCAPP.DTOS.DTOS;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class ActorController : ControllerBase
    {
        IActorService _Service;
        IWebHostEnvironment _environment;

        public ActorController(IActorService Service, IWebHostEnvironment webHostEnvironment)
        {
            _Service = Service;
            _environment = webHostEnvironment;


        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Actor ()
        {
            var list = _Service.GetAsync();
            return Ok(await list);
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ActorToAddDTO dto)
        {
            if (ModelState.IsValid)
            {

                //if (file != null)
                //{
                //    string folder = "s//";
                //    dto.ProfilePictureURL = await UploadImage(folder, file);
                //}
                await _Service.AddAsync(dto);
                return Ok();
            }

            return BadRequest();
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute]int id)
        {

            var detail = await _Service.GetByIdAsync(id);
            if (detail != null)
            {
                return Ok(detail);

            }
            return BadRequest();    

        }

        [Authorize(Roles = "Admin")]


        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute]int id, [FromBody] ActorToUpdateDTO dto, [FromForm] IFormFile file)
        {
            Actor actor  = await _Service.GetByIdAsync(id);
            if (dto.ProfilePictureURL != actor.ProfilePictureURL)
            {
                string folder = "actors/actor/";
                dto.ProfilePictureURL = await UploadImage(folder, file);

                await _Service.UpdateAsync(id, dto);
                return Ok();


            }


            dto.ProfilePictureURL = actor.ProfilePictureURL;
            await _Service.UpdateAsync(id, dto);
            return Ok();




        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            await _Service.DeleteAsync(id);


            return Ok();




        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_environment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }
}
