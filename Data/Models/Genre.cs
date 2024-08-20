using System.ComponentModel.DataAnnotations;

namespace ClearMechanic.Data.Models {
    public class Genre {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual IList<Movie>? Movies { get; set; }
    }   
}