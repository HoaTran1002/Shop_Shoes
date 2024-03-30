using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoes.Areas.Admin.Models
{
    [Table("Products")]
 
    public class Product
    {
        [Key]
        public int MASP { get; set; }
		public string TENSP { get; set; }
        [ForeignKey("PRODUCTTYPE")]
        public int MALOAI { get; set; }
        [ForeignKey("COLORTYPE")]
        public int MAMAU { get; set; }
        public string HINHANH { get; set; }
        public string MOTA { get; set; }
        public Double GIA { get; set; }
        public int KICHTHUOC { get; set; }
        public int SOLUONG { get; set; }
        public DateTime NGAYTHEM { get; set; }
        public DateTime? NGAYSUA { get; set; } = null;
    }
}
/*
    MASP INT IDENTITY(1,1) PRIMARY KEY,
	TENSP NVARCHAR(20),
	MALOAI INT,
	MAMAU INT,
	HINHANH NVARCHAR(100),
	MOTA NVARCHAR(100),
	DANHGIA INT,--VÍ DỤ 1~ MỘT SAO, 2~ HAI SAO
	GIA FLOAT,
	SOLUONG INT,
	NGAYTHEM DATETIME,
 */