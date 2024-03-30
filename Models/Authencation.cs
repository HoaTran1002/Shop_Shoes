using System.ComponentModel.DataAnnotations;

namespace Shoes.Models
{
    public class Authencation
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter User Name.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter Pass Word.")]
        public string PassWord { get; set; }
    }
}
/*
 ID INT IDENTITY(1,1) PRIMARY KEY,
	USERNAME NVARCHAR(50),
	PASSWORD VARCHAR(20),
	ROLE VARCHAR(10)
 
 */