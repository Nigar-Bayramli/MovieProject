using DTOS.DTOS.UserDTOS;
using Entities;
using MVCAPP.DTOS.DTOS;
using MVCAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL.Abstract
{
    public interface IUserService
    {
        Task<List<UserToListDTO>> GetAsync();
        Task AddAsync(UserToAddDTO user);
        Task<ApplicationUser> GetByIdAsync(int id);

       
        Task UpdateAsync(int id, UserToUpdateDTO user);
        Task DeleteAsync(int id);
       
    }
}
