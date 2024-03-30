using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoes.Areas.Admin.Models
{
    [Table("Logins")]
    public class Login
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool KeeploggedIn { get; set; }
    }
}
