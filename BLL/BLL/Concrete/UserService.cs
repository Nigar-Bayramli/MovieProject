using AutoMapper;
using BLL.BLL.Abstract;
using DTOS.DTOS.UserDTOS;
using Entities;
using MVCAPP.DAL.Generic_Repository.Abstract;
using MVCAPP.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace BLL.BLL.Concrete
{
    public class UserService : IUserService
    {
        IMapper _mapper;
    
        private readonly IRepository<ApplicationUser> _repository;
        public UserService(IMapper mapper, IRepository<ApplicationUser> repository)
        {


            _mapper = mapper;

            _repository = repository;
         


        }
       
        public async Task AddAsync(UserToAddDTO user)
        {
         
          ApplicationUser applicationUser = _mapper.Map<ApplicationUser>(user);
            await _repository.AddAsync(applicationUser);
            
        }

        public async Task DeleteAsync(int id)
        {
          await  _repository.DeleteAsync(id);
        }

        public async Task<List<UserToListDTO>> GetAsync()
        {
            List<ApplicationUser> list = await _repository.GetAllAsync();
            var dtos = _mapper.Map< List < UserToListDTO >> (list);
            return dtos;
        }

        public async Task<ApplicationUser> GetByIdAsync(int id)
        {
            ApplicationUser applicationUser =await _repository.GetByIdAsync(id);
            return applicationUser;
        }

        public async Task UpdateAsync(int id, UserToUpdateDTO dto)
        {
            ApplicationUser user = await _repository.GetByIdAsync(id); 
            user.UserName = dto.UserName;
            user.FullName = dto.FullName;
            user.Email = dto.Email;
            user.Password = dto.Password;
          await  _repository.UpdateAsync(user);
            
        }

        
    }
}
