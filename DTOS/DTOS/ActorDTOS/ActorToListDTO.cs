using MVCAPP.DTOS.MoviesDTOS;

namespace MVCAPP.DTOS.DTOS
{
    public class ActorToListDTO
    {
        public int Id { get; set; }

      
        public string ProfilePictureURL { get; set; }


        public string FullName { get; set; }


        public string Bio { get; set; }
        public List<MovieToListDTO> Movies { get; set; }    

    }
}
