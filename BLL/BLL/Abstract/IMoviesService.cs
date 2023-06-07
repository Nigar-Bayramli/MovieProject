using DTOS.DTOS.MoviesDTOS;
using MVCAPP.DAL.Generic_Repository.Abstract;
using MVCAPP.DTOS.DTOS;

using MVCAPP.DTOS.MoviesDTOS;
using MVCAPP.Models;

namespace MVCAPP.BLL.Abstract
{


    public interface IMoviesService
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<List<MovieToListDTO>> GetAsync();
        Task<MovieToUpdateDTO> GetDTOAsync(Movie movie);
      
        Task AddNewMovieAsync(MovieToAddDTO data);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, MovieToUpdateDTO data);
        Task<List<MovieSalesData>> GetMovieSalesCountAsync();
    }
}
