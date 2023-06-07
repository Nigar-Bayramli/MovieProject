using Entities.Models.Entity;
using MVCAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PaymentDetail : IEntity
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public ApplicationUser User { get; set; }
        public int UserId { get; set; }
        public DateTime PaymentDate { get; set; }
        public double TotalAmount { get; set; }
       
        public bool IsDeleted { get; set; }
    }
}
