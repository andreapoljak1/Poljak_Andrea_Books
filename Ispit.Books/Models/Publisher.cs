using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ispit.Books.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }

        [NotMapped]
        public ICollection<Book>? Books { get; set; }
    }
}
