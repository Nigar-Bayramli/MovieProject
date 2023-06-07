using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using Entities;
using Entities.Models.Entity;

namespace MVCAPP.Models
{
    public class Movie : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

       
        public List<Actor> Actors { get; set; }

        public Cinema Cinema { get; set; }
        public int CinemaId { get; set; }



        public Producer Producer { get; set; }
        public int ProducerId { get; set; }
        public bool IsDeleted { get; set; }
    }
}