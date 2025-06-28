using Lab04.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab04.Controllers
{
	public class EmployeeController : Controller
	{
		public IActionResult IsExistedEmployee(string EmployeeNo)
		{
			var emps = new List<string> { "admin", "employee", "EMP0000" };
			if (emps.Contains(EmployeeNo))
			{
				return Json($"Mã {EmployeeNo} đã có");
			}
			return Json(true);
		}
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Employee emp)
		{
			return View();
		}
	}
}
