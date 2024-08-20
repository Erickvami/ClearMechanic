using System.ComponentModel.DataAnnotations;

namespace ClearMechanic.Data.Models {
    public class Movie {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateTime Registered { get; set; }
        public bool IsDeleted { get; set; }
        public string? ImageURI { get; set; }

        public virtual IList<Actor>? Actors { get; set; }
        public virtual IList<Genre>? Genres { get; set; }
    }   
}