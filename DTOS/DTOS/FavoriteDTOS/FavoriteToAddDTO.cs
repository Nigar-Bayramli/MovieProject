using MVCAPP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTOS.FavoriteDTOS
{
   public class FavoriteToAddDTO
    {
        [Required] 
        public int MovieId { get; set; }

       
    }
}
