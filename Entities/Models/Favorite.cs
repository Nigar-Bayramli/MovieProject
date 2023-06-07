using Entities.Models.Entity;
using MVCAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Favorite : IEntity
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public ApplicationUser User { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
