using Entities.Models.Entity;
using MVCAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class  Card : IEntity
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }   
        public int UserId { get; set; }
        public string CardNumber { get; set; }
        public string CardholderName { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
        public bool IsDeleted { get; set; }
    }
}
