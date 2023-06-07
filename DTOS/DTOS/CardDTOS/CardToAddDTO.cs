using MVCAPP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTOS.CardDTOS
{
    public class CardToAddDTO
    {
        [Required]     
        
        public string CardNumber { get; set; }
        [Required]
        public string CardholderName { get; set; }
        [Required]
        public string ExpirationDate { get; set; }
        [Required]
        public string CVV { get; set;}


    }
}
