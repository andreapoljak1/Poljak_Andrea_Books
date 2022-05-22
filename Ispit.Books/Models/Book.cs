using Ispit.Books.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ispit.Books.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public int AuthorId { get; set; }

        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
        public string? UserId { get; set; }

        [NotMapped]
        public string AuthorName { get; set; }

        [NotMapped]
        public string PublisherName { get; set; }
    }
}
