using DTOS.DTOS.RatingDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL.Abstract
{
    public interface IRatingService
    {
        Task AddAsync(RatingToAddDTO dto, int id);
        Task<List<RatingToListDTO>> GetAsync();
        Task<List<RatingToListDTO>> GetMoviesAscending();
    }
}
