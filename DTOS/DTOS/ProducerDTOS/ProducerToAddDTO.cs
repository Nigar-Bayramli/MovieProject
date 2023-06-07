using Microsoft.AspNetCore.Http;
using MVCAPP.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVCAPP.DTOS.ProducerDTOS
{
    public class ProducerToAddDTO
    {
    

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureURL { get; set; }
 

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }
       


       
    }
}
