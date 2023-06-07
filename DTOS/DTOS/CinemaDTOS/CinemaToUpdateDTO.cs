using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVCAPP.DTOS.CinemaDTOS
{
    public class CinemaToUpdateDTO
    {
        [Display(Name = "Cinema Logo")]
        [Required(ErrorMessage = "Cinema logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Cinema name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Cinema description is required")]
        public string Description { get; set; }


        public List<int> MovieIds { get; set; }
    }
}
