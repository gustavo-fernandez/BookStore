using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Publisher : BaseEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Url { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
