using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApi.Models
{
	[Table("Account")]
	public class Account
	{
		[Key]
		[StringLength(16, MinimumLength = 12)]
		public string AccountNumber { get; set; }
		[MaxLength(150)]
		public string AccountHolder { get; set; }
		[StringLength(10, MinimumLength = 10)]
		public string Phone { get; set; }
		[StringLength(12, MinimumLength = 12)]
		public string PersonalId { get; set; }
		public DateTime PersonIdExpireDate { get; set; }
		[Range(0, double.MaxValue)]
		public double Balance { get; set; }
	}
}
