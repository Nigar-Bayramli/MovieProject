using MVCAPP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DTOS.DTOS.UserDTOS
{
    public class UserToAddDTO
    {
        [Key]
      
        [Display(Name = "Full name")]
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string Email { get; set; }
    
    }
}
