using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DTOS.DTOS.UserDTOS
{
    public class UserToUpdateDTO
    {
        [Key]

        [Display(Name = "Full name")]
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string? Password { get; set; }
        public string Email { get; set; }

    }
}
