using System.ComponentModel.DataAnnotations;

namespace Lab04.Models
{
	public class Employee
	{
		public int Id { get; set; }

		[Display(Name = "Mã nhân viên")]
		[RegularExpression("EMP[0-9]{4}", ErrorMessage = "Mã nhân viên có dạng EMPxxxx. Ví dụ: EMP0123")]
		public string EmployeeNo { get; set; }

		[StringLength(150, MinimumLength = 3, ErrorMessage = "Độ dài từ 3 --> 150 kí tự")]
		public string FullName { get; set; }

		[EmailAddress]
		public string Email { get; set; }

		[EmailAddress]
		[Compare("Email", ErrorMessage = "Email không khớp")]
		public string ConfirmEmail { get; set; }

		[Url]
		public string? Website { get; set; }


		[DataType(DataType.Date)]
		public DateTime BirthDate { get; set; }

		public bool Gender { get; set; } = true;

		[Range(0, double.MaxValue)]
		public double Salary { get; set; }

		public bool IsPartTime { get; set; }

		public string Address { get; set; }

		[RegularExpression(@"0[98753]\d{8}")]
		[Display(Name = "Số di động")]
		public string MobilePhone { get; set; }

		[CreditCard]
		public string? CreditCard { get; set; }

		[MaxLength(255, ErrorMessage ="Tối đa 255 kí tự")]
		[DataType(DataType.MultilineText)]
		public string? Description { get; set; }
	}
}
