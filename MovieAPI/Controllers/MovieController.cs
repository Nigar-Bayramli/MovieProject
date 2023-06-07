using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCAPP.BLL.Abstract;
using MVCAPP.BLL.Concrete;
using MVCAPP.DTOS.DTOS;
using MVCAPP.DTOS.MoviesDTOS;
using MVCAPP.Models;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        IMoviesService _moviesService;
        IWebHostEnvironment _environment;
        public MovieController(IMoviesService moviesService, IWebHostEnvironment environment)
        {
            _moviesService = moviesService;
            _environment = environment;
        }
        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_environment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
        [HttpGet]
        public async Task<IActionResult> Movie()
        {
            var list = _moviesService.GetAsync();
            return Ok(await list);

        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]MovieToAddDTO dto, [FromForm] IFormFile file)
        {
            if (ModelState.IsValid) { 
                string folder = "movies/movie/";
            dto.ImageURL = await UploadImage(folder, file);





            await _moviesService.AddNewMovieAsync(dto);
                return Ok();

        }
            return BadRequest();

        }

        [HttpGet("{searchString}")]

        public async Task<IActionResult> Filter([FromRoute]string searchString)
        {
            var allMovies = await _moviesService.GetAsync();

            if (!string.IsNullOrEmpty(searchString))
            {


                var filteredResultNew = allMovies.Where(n => n.Name.Contains(searchString)).ToList();

                return Ok(filteredResultNew);
            }

            return BadRequest("Not found");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] MovieToUpdateDTO dto, IFormFile file)
        {
            Movie Movie = await _moviesService.GetMovieByIdAsync(id);
            if (dto.ImageURL != Movie.ImageURL)
            {
                string folder = "Movies/Movie/";
                dto.ImageURL = await UploadImage(folder, file);

                await _moviesService.UpdateAsync(id, dto);
                return Ok();


            }


            dto.ImageURL = Movie.ImageURL;
            await _moviesService.UpdateAsync(id, dto);
            return Ok();




        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _moviesService.DeleteAsync(id);
            return Ok();

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute]int id)
        {
            var movieDetail = await _moviesService.GetMovieByIdAsync(id);
            
            return Ok(movieDetail);
        }
        [HttpGet("Sales")]
        public async Task<IActionResult> GetMovieSales()
        {
            var movieDetail = await _moviesService.GetMovieSalesCountAsync();

            return Ok(movieDetail);
        }
    }
}
