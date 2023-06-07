using DTOS.DTOS.FavoriteDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL.Abstract
{
    public interface IFavoriteService
    {
        Task AddAsync(FavoriteToAddDTO dto, int id);
        Task<List<FavoriteToListDTO>> GetAsync(int id);
      
    }
}
