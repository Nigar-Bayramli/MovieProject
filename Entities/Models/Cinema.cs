using Entities.Models.Entity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVCAPP.Models
{
    public class Cinema : IEntity
    {

        [Key]
        public int Id { get; set; }

    [Display(Name = "Cinema Logo")]
    [Required(ErrorMessage = "Cinema logo is required")]
    public string Logo { get; set; }

    [Display(Name = "Cinema Name")]
    [Required(ErrorMessage = "Cinema name is required")]
    public string Name { get; set; }

    [Display(Name = "Description")]
    [Required(ErrorMessage = "Cinema description is required")]
    public string Description { get; set; }

 
    public List<Movie> Movies { get; set; }
        public bool IsDeleted { get; set; }
    }
}