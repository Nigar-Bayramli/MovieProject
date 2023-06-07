using DTOS.DTOS.UserDTOS;
using MVCAPP.DTOS.MoviesDTOS;
using MVCAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTOS.CommentDTOS
{
   public class CommentToListDTO
    {
        public int Id { get; set; }
        public string UserComment { get; set; }
        public UserToListDTO User { get; set; }
  
        public DateTime DateTime { get; set; }
        public MovieToListDTO Movie { get; set; }
     
    }
}
