using MVCAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTOS.PaymentDetailsDTO
{
    public class PaymentDetailToAddDTO
    {
      
        public int OrderId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime PaymentDate { get; set; }
        public double TotalAmount { get; set; }
        public int UserId { get; set; }
    }
}
