using Microsoft.AspNetCore.Http;
using MVCAPP.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCAPP.DTOS.MoviesDTOS
{
    public class MovieToUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public string ImageURL { get; set; }
  
        public DateTime StartDate = DateTime.UtcNow;

        public DateTime EndDate = DateTime.UtcNow;
        public MovieCategory MovieCategory { get; set; }


    


        public List<int> Ids { get; set; }


        public int CinemaId { get; set; }




        public int ProducerId { get; set; }
    }
}
