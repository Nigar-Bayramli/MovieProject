using MVCAPP.DTOS.CinemaDTOS;
using MVCAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL.Abstract
{
    public interface ICinemaService
    {
        Task<List<CinemaToListDTO>> GetAsync();
        Task AddAsync(CinemaToAddDTO CinemaToAddDTO);
        Task<Cinema> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
