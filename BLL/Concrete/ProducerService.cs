using AutoMapper;
using BLL.BLL.Abstract;
using Entities;
using MVCAPP.DAL.Generic_Repository.Abstract;
using MVCAPP.DTOS.ProducerDTOS;
using MVCAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class ProducerService : IProducerService
    {
        IMapper _mapper;

        IRepository<Producer> _repository;

        public ProducerService(IMapper mapper, IRepository<Producer> repository)
        {

            _mapper = mapper;

            _repository = repository;
        }
        public async Task AddAsync(ProducerToAddDTO producerToAddDTO)
        {
            Producer producer = _mapper.Map<Producer>(producerToAddDTO);
            await _repository.AddAsync(producer);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<ProducerToListDTO>> GetAsync()
        {
            var list = _repository.GetAllAsync();
            List<ProducerToListDTO> dtos = _mapper.Map<List<ProducerToListDTO>>(list);
            return dtos;
        }

        public async Task<Producer> GetByIdAsync(int id)
        {
            Producer producer = await _repository.GetByIdAsync(id);

            return producer;
        }
    }
}
