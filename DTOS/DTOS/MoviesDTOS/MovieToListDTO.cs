using MVCAPP.DTOS.DTOS;
using MVCAPP.DTOS.CinemaDTOS;
using MVCAPP.DTOS.ProducerDTOS;
using MVCAPP.Models;

namespace MVCAPP.DTOS.MoviesDTOS
{
    public class MovieToListDTO
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }


        //public List<ActorToListDTO> Actors { get; set; }

        public CinemaToListDTO Cinema { get; set; }
      



        public ProducerToListDTO Producer { get; set; }
      
    }
}
