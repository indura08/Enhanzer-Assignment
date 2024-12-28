using System.ComponentModel.DataAnnotations;

namespace BookMate.Data_Models
{
    public class Book 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Isbn { get; set; }
        public DateOnly PublicationDate { get; set; }

    }
}
