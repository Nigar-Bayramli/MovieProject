using MVCAPP.DTOS.MoviesDTOS;
using MVCAPP.Models;

namespace MVCAPP.DTOS.ShoppingCartDTOS
{
    public class ShoppingCartToListDTO
    {




        public int Id { get; set; }

        public int Amount { get; set; }
        public double Price { get; set; }
        public double DiscountAmount { get; set; }
        public ApplicationUser User { get; set; }
   

        public Movie Movie { get; set; }
     
        public Order? Order { get; set; }
     


    }
}
