using Entities;
using MVCAPP.DTOS.DTOS;
using MVCAPP.DTOS.ProducerDTOS;
using MVCAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL.Abstract
{
    public interface IProducerService
    {
        Task<List<ProducerToListDTO>> GetAsync();
        Task AddAsync(ProducerToAddDTO producerToAddDTO);
        Task<Producer> GetByIdAsync(int id);
        Task DeleteAsync(int id);
      
    }
}
