using System.ComponentModel.DataAnnotations;

namespace Lab03.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [MinLength(5, ErrorMessage = "Tối thiểu 5 kí tự")]
        public string FullName { get; set; }
        [Range(0, 10, ErrorMessage = "Điểm từ 0 đến 10")]
        public double Mark { get; set; }
        public string Grade
        {
            get
            {
                if (Mark >= 8.5) return "A";
                if (Mark >= 7) return "B";
                if (Mark >= 5.5) return "C";
                if (Mark >= 4) return "D";
                return "F";
            }
        }
    }
}
