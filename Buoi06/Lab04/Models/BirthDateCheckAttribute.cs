
using System.ComponentModel.DataAnnotations;

namespace Lab04.Models
{
	public class BirthDateCheckAttribute : ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var birthDate = (DateTime?)value;
			var age = DateTime.Now.Year - birthDate.Value.Year;
			if (age < 16 || age > 65)
			{
				return new ValidationResult("Tuổi từ 16 .. 65");
			}
			return ValidationResult.Success;
		}
	}
}