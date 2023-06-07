using DTOS.DTOS.CardDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL.Abstract
{
    public interface ICardService
    {
        Task AddAsync(CardToAddDTO dto, int id);
    }
}
