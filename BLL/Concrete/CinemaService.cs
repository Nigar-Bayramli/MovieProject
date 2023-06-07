using AutoMapper;
using BLL.BLL.Abstract;
using Entities;
using MVCAPP.DAL.Generic_Repository.Abstract;
using MVCAPP.DTOS.CinemaDTOS;
using MVCAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class CinemaService : ICinemaService
    {

        IMapper _mapper;

        IRepository<Cinema> _repository;

        public CinemaService(IMapper mapper, IRepository<Cinema> repository)
        {

            _mapper = mapper;

            _repository = repository;
        }
        public async Task AddAsync(CinemaToAddDTO CinemaToAddDTO)
        {
            Cinema Cinema = _mapper.Map<Cinema>(CinemaToAddDTO);
            await _repository.AddAsync(Cinema);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<CinemaToListDTO>> GetAsync()
        {
            var list = _repository.GetAllAsync();
            List<CinemaToListDTO> dtos = _mapper.Map<List<CinemaToListDTO>>(list);
            return dtos;
        }

        public async Task<Cinema> GetByIdAsync(int id)
        {

           Cinema cinema = await _repository.GetByIdAsync(id);

            return cinema;
        }
    }
}
