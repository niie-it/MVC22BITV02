using System.ComponentModel.DataAnnotations;

namespace DemoApi.Models
{
	public class RegisterAccount
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

		[CheckExpireDate]
		public DateTime PersonIdExpireDate { get; set; }

		[Range(100000, double.MaxValue)]
		public double Balance { get; set; }
	}
}
