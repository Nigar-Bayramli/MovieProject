using MVCAPP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTOS.CommentDTOS
{
   public class CommentToAddDTO
    {
        [Required]
        public string UserComment { get; set; }


        [Required]
        public int MovieId { get; set; }
    }
}
