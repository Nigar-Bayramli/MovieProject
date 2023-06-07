using Microsoft.AspNetCore.Http;
using MVCAPP.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MVCAPP.DTOS.MoviesDTOS
{
    public class MovieToAddDTO
    {


       
       
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }
  
     
     
     
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate = DateTime.UtcNow;

        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate = DateTime.UtcNow;
        [Required(ErrorMessage = "MovieCategory is required")]
        public MovieCategory MovieCategory { get; set; }

        [Required(ErrorMessage = "Movie (s) is required")]
        public List<int> Ids { get; set; }

        [Required(ErrorMessage = "Movie cinema is required")]
        public int CinemaId { get; set; }


        [Required(ErrorMessage = "Movie producer is required")]
        public int ProducerId { get; set; }
        [Required]
        public string ImageURL { get; set; }
    }
}
