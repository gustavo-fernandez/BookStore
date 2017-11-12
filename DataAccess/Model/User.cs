using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
