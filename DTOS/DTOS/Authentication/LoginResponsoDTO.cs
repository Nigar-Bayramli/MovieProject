using MVCAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTOS.Authentication
{
      public class LoginResponsoDTO
    {
       public ApplicationUser User { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
