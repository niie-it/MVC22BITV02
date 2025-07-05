using System.ComponentModel.DataAnnotations.Schema;

namespace Lab06.Models
{
	[Table("KhachHang")]
	public class Customer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public bool IsActive { get; set; } = true;
	}
}
