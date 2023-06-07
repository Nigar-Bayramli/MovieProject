using Entities.Models;
using Entities.Models.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCAPP.Models
{
    public class Order : IEntity
    {
        [Key]
        public int Id { get; set; }


        public ApplicationUser User { get; set; }
        public int UserId { get; set; }

        
       public Card Card { get; set; }
        public int CardId { get; set; } 
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPayyed { get; set; }
        public bool HasDiscount { get; set; }
    }
}
