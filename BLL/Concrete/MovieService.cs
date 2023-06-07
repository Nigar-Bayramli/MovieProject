using AutoMapper;
using DAL;
using DTOS.DTOS.MoviesDTOS;
using Microsoft.EntityFrameworkCore;
using MVCAPP.BLL.Abstract;
using MVCAPP.DAL.Generic_Repository.Abstract;

using MVCAPP.DTOS.MoviesDTOS;
using MVCAPP.DTOS.ProducerDTOS;
using MVCAPP.Models;

using System.Collections.Generic;
using System.Linq.Expressions;

namespace MVCAPP.BLL.Concrete
{
    public class MovieService : IMoviesService
    {

        IMapper _mapper;
        MyAppDbContext _context;
        private readonly IRepository<Movie> _movieRepository;
        public MovieService(IMapper mapper, IRepository<Movie> repository, MyAppDbContext myAppDbContext)
        {

            _mapper = mapper;
           
            _movieRepository = repository;
            _context = myAppDbContext;
         

        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            Movie movie = await _movieRepository.GetByIdAsync(id, c => c.Cinema, p => p.Producer, x => x.Actors);
            return movie;
        }

        public async Task<List<MovieToListDTO>> GetAsync()
        {
            List<Movie> list = await _movieRepository.GetAllAsync(c => c.Cinema, p => p.Producer, x => x.Actors);
            var dtos = _mapper.Map<List<MovieToListDTO>>(list);   
            return  dtos;
        }

        public async Task AddNewMovieAsync(MovieToAddDTO data)
        {
            Movie movie = _mapper.Map<Movie>(data);
           await _movieRepository.AddAsync(movie);
        }

        public async Task UpdateAsync(int id, MovieToUpdateDTO data)
        {
            Movie movie = await _movieRepository.GetByIdAsync(id, c => c.Cinema, p => p.Producer, x => x.Actors);
         movie.Name = data.Name;
            movie.Description = data.Description;
            movie.MovieCategory = data.MovieCategory;
                movie.Price  = data.Price;
            movie.StartDate = data.StartDate;
                movie.EndDate = data.EndDate;
            movie.ImageURL = data.ImageURL;
            movie.CinemaId = data.CinemaId;
            movie.ProducerId = data.ProducerId;
            await _movieRepository.UpdateAsync(movie);

        }

   

        public async Task<MovieToUpdateDTO> GetDTOAsync(Movie movie)
        {
            MovieToUpdateDTO dto = _mapper.Map<MovieToUpdateDTO>(movie);
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            await _movieRepository.DeleteAsync(id); 
        }

        public async Task<List<MovieSalesData>> GetMovieSalesCountAsync()
        {
            var movieSalesCount = _context.ShoppingCartItems
           .Where(item => item.Order != null && item.Order.IsPayyed)
           .GroupBy(item => item.MovieId)
           .Select(group => new
           {
               MovieId = group.Key,
               SalesCount = group.Sum(item => item.Amount)
           })
           .ToList();

            var movieSalesData = new List<MovieSalesData>();

            foreach (var sales in movieSalesCount)
            {
                var movie = _context.Movies.FirstOrDefault(m => m.Id == sales.MovieId);
                if (movie != null)
                {
                    movieSalesData.Add(new MovieSalesData
                    {
                        MovieId = sales.MovieId,
                        MovieName = movie.Name,
                        SalesCount = sales.SalesCount
                    });
                }
            }
            return movieSalesData;
        }
    }
}
