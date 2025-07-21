
using System.ComponentModel.DataAnnotations;

namespace DemoApi.Models
{
	public class CheckExpireDateAttribute : ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var data = (DateTime?)value;
			if (data != null)
			{
				if (data.Value < DateTime.Now)
				{
					return new ValidationResult("CCCD hết hạn");
				}
				return ValidationResult.Success;
			}
			return new ValidationResult("CCCD không hợp lệ");
		}
	}
}