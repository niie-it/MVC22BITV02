using Lab04.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab04.Controllers
{
	public class EmployeeController : Controller
	{
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
