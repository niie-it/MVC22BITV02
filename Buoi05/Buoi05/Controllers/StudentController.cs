using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Buoi05.Controllers
{
	public class StudentController : Controller
	{
		public IActionResult Register()
		{
			var data = new List<SelectListItem>
			{
				new SelectListItem {Text = "Tin học", Value = "Tin học" },
				new SelectListItem {Text = "Ngoại ngữ", Value = "Ngoại ngữ" },
				new SelectListItem {Text = "Quốc phòng", Value = "Quốc phòng" },
			};
			ViewBag.Cerfiticates = new SelectList(data);
			return View();
		}
	}
}
