using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Entities.Models.Entity;

namespace MVCAPP.Models
{
    public class ShoppingCartItem : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }
        public double Price { get; set; }
        public double DiscountAmount { get; set; }
       public ApplicationUser User { get; set; }    
        public int UserId { get; set; }
       
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public Order? Order { get; set; }
        public int? OrderId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
