using AutoMapper;
using BLL.BLL.Abstract;
using DTOS.DTOS.CardDTOS;
using Entities.Models;
using MVCAPP.DAL.Generic_Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL.Concrete
{
    public class CardService : ICardService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Card> _repository;
        public CardService(IRepository<Card> repository)
        {
            _repository = repository;
            
        }
        public async Task AddAsync(CardToAddDTO dto, int id)
        {
            Card card = _mapper.Map<Card>(dto);
            card.UserId = id;
          await  _repository.AddAsync(card);
        }
    }
}
