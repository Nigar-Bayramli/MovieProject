using BLL.BLL.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCAPP.DTOS.ProducerDTOS;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {

        IProducerService _Service;
        IWebHostEnvironment _environment;

        public ProducerController(IProducerService Service, IWebHostEnvironment webHostEnvironment)
        {
            _Service = Service;
            _environment = webHostEnvironment;


        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Producer()
        {
            var list = _Service.GetAsync();
            return Ok(await list);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProducerToAddDTO dto, [FromForm] IFormFile file)
        {
            if (ModelState.IsValid)
            {

                if (file != null)
                {
                    string folder = "s//";
                    dto.ProfilePictureURL = await UploadImage(folder, file);
                }
                await _Service.AddAsync(dto);
                return Ok();
            }

            return BadRequest();
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {

            var detail = await _Service.GetByIdAsync(id);
            if (detail != null)
            {
                return Ok(detail);

            }
            return BadRequest();

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
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
