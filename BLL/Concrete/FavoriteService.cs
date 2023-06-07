using AutoMapper;
using BLL.BLL.Abstract;
using DAL;
using DTOS.DTOS.FavoriteDTOS;
using Entities.Models;
using MVCAPP.DAL.Generic_Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Favorite> _repository;
        MyAppDbContext _appDbContext;
        public FavoriteService(IMapper mapper, IRepository<Favorite> repository, MyAppDbContext myAppDbContext)
        {
            _mapper = mapper;
            _repository = repository;
            _appDbContext = myAppDbContext;


        }

        public async Task AddAsync(FavoriteToAddDTO dto, int id)
        {
            Favorite Favorite = _mapper.Map<Favorite>(dto);
            Favorite.UserId = id;
            await _repository.AddAsync(Favorite);
        }

        public async Task<List<FavoriteToListDTO>> GetAsync(int id)
        {
            List<Favorite> Favorites = _appDbContext.Favorites.Where(f => f.UserId == id).ToList(); 
            List<FavoriteToListDTO> dtos = _mapper.Map<List<FavoriteToListDTO>>(Favorites);
            return  dtos;

        }
    }
}
