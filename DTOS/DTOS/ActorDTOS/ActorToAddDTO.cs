using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MVCAPP.DTOS.DTOS
{
    public class ActorToAddDTO
    {


        [Required]
       

        public string ProfilePictureURL { get; set; }
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Bio { get; set; }

    }
}
