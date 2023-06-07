using Microsoft.AspNetCore.Http;

namespace MVCAPP.DTOS.DTOS
{
    public class ActorToUpdateDTO
    {
    

        public int Id { get; set; } 
        public string ProfilePictureURL { get; set; }
        

        public string FullName { get; set; }


        public string Bio { get; set; }

    }
}
