﻿using MVCAPP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTOS.RatingDTOS
{
   public class RatingToAddDTO
    {
        [Required]
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public int Review { get; set; }


        [Required]
       
        public int MovieId { get; set; }
    }
}
