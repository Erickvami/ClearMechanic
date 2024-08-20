using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClearMechanic.Data.Models {
    public class Actor {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageURI { get; set; }
        public DateTime Registered { get; set; }
        public bool IsDeleted { get; set; }

        public virtual IList<Movie>? Movies { get; set; }
    }   
}