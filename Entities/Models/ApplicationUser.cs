using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using Entities.Models.Entity;

namespace MVCAPP.Models
{
    public class ApplicationUser : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Full name")]
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public UserRoles Roles { get; set; }
        public bool IsDeleted { get; set; }
    }
}
