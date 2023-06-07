using System.ComponentModel.DataAnnotations;
using Entities.Models.Entity;
using MVCAPP.Models;

namespace Entities
{
    public class Actor : IEntity
    {
        [Key]
        public int Id { get; set; }


        public string ProfilePictureURL { get; set; }


        public string FullName { get; set; }


        public string Bio { get; set; }


        public List<Movie> Movies { get; set; }
        public bool IsDeleted { get; set; }
    }
}
