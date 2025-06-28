using System.ComponentModel.DataAnnotations;

namespace Buoi05.Models
{
	public class Student
	{
		public int StudentId { get; set; }
		public string StudentName { get; set;}
		public string Certificate { get; set;}

		[DataType(DataType.MultilineText)]
		public string Description { get; set;}
		public string Image { get; set;}
	}
}
