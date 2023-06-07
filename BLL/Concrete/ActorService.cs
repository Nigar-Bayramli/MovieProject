using AutoMapper;
using DAL.Migrations;
using Entities;
using MVCAPP.BLL.Abstract;
using MVCAPP.DAL.Generic_Repository.Abstract;
using MVCAPP.DTOS.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
   public class ActorService : IActorService
    {
        IMapper _mapper;

        IRepository<Actor> _repository;
        public ActorService(IMapper mapper, IRepository<Actor> repository)
        {

            _mapper = mapper;

            _repository = repository;


        }
        public async Task AddAsync(ActorToAddDTO dto)
        {
            Actor actor = _mapper.Map<Actor>(dto);
            await _repository.AddAsync(actor);

        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);

        }

        public async Task<List<ActorToListDTO>> GetAsync()
        {
            List<Actor> actors = await _repository.GetAllAsync();
            List<ActorToListDTO> dtos = _mapper.Map<List<ActorToListDTO>>(actors);
            return dtos;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {

            Actor actor = await _repository.GetByIdAsync(id);
            ActorToListDTO dto = _mapper.Map<ActorToListDTO>(actor);
            return actor;
        }

        public async Task UpdateAsync(int id, ActorToUpdateDTO dto)
        {
            Actor actor = await _repository.GetByIdAsync(id);

            actor.Bio = dto.Bio;
            actor.FullName = dto.FullName;
            actor.ProfilePictureURL = dto.ProfilePictureURL;

            await _repository.UpdateAsync(actor);

        }

    }
}
