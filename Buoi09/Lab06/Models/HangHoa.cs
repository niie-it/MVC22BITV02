using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab06.Models
{
	[Table("HangHoa")]
	public class HangHoa
	{
		[Key]
		public int MaHh { get; set; }

		[MaxLength(100)]
		public string TenHh { get; set; }

		public string? Hinh { get; set; }

		public double DonGia { get; set; }

		public int MaLoai { get; set; }

		[ForeignKey("MaLoai")]
		public Loai Loai { get; set; }
	}
}
