using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationRider.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        
        public int CategoryId { get; set; } = 0;
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}