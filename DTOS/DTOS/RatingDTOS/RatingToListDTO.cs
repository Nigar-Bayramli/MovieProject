using DTOS.DTOS.UserDTOS;
using MVCAPP.DTOS.MoviesDTOS;
using MVCAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTOS.RatingDTOS
{
    public class RatingToListDTO
    {
        public int Id { get; set; }
        public int Review { get; set; }
        public UserToListDTO User { get; set; }
  
        public MovieToListDTO Movie { get; set; }
      
    }
}
