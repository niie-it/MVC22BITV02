using Lab03.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab03.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manage(string SaveType, Student model)
        {
            var projectFolder = Directory.GetCurrentDirectory();

            if (SaveType == "Lưu TXT")
            {
                var fileName = Path.Combine(projectFolder, "wwwroot", "Student.txt");
                var thongTin = new string[]
                {
                    "Mã số: " + model.StudentId,
                    "Họ tên: " + model.FullName,
                    "Điểm: " + model.Mark,
                    "Loại: " + model.Grade
                };
                System.IO.File.WriteAllLines(fileName, thongTin);
            }
            else if (SaveType == "Lưu JSON")
            {
                var fileName = Path.Combine(projectFolder, "wwwroot", "Student.json");
                var jsonString = System.Text.Json.JsonSerializer.Serialize(model);
                System.IO.File.WriteAllText(fileName, jsonString);
            }
            return View("Index", model);
        }

        public IActionResult ReadData(string filetype)
        {
            var projectFolder = Directory.GetCurrentDirectory();
            var model = new Student();
            if (filetype == "JSON")
            {
                var fileName = Path.Combine(projectFolder, "wwwroot", "Student.json");
                var jsonStr = System.IO.File.ReadAllText(fileName);
                model = System.Text.Json.JsonSerializer.Deserialize<Student>(jsonStr);
            }
            return View("Index", model);
        }
    }
}
