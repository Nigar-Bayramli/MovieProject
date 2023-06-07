using AutoMapper;
using BLL.BLL.Abstract;
using DAL;
using DTOS.DTOS.RatingDTOS;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using MVCAPP.DAL.Generic_Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
   public class RatingService : IRatingService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Rating> _repository;
        MyAppDbContext _appDbContext;
        public RatingService(IMapper mapper, IRepository<Rating> repository, MyAppDbContext myAppDbContext)
        {
            _mapper = mapper;
            _repository = repository;
            _appDbContext = myAppDbContext;


        }

        public async Task AddAsync(RatingToAddDTO dto, int id)
        {
            Rating rating = _mapper.Map<Rating>(dto);
            rating.UserId = id;
            await _repository.AddAsync(rating);
        }

        public async Task<List<RatingToListDTO>> GetAsync()
        {
            List<Rating> ratings = await _repository.GetAllAsync();
            List<RatingToListDTO> dtos = _mapper.Map<List<RatingToListDTO>>(ratings);
            return dtos;

        }

        public async Task<List<RatingToListDTO>> GetMoviesAscending()
        {
            var ratings = _appDbContext.Ratings.OrderByDescending(m => m.Review).ToListAsync();
            List<RatingToListDTO> dtos = _mapper.Map<List<RatingToListDTO>>(ratings);
            return dtos;
        }
    }
}
