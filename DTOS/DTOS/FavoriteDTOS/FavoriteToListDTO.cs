using DTOS.DTOS.UserDTOS;
using MVCAPP.DTOS.MoviesDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTOS.FavoriteDTOS
{
   public class FavoriteToListDTO
    {
        public UserToListDTO User { get; set; }

      
        public MovieToListDTO Movie { get; set; }
    }
}
