using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Book : BaseEntity
    {
        [Key]
        public string Isbn { get; set; }
        [Required]
        public string Title { get; set; }
        public int PublisherId { get; set; }
        [Required]
        public decimal Price { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}
