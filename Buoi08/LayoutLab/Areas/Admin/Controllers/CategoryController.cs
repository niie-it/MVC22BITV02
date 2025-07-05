using Microsoft.AspNetCore.Mvc;

namespace LayoutLab.Areas.Admin.Controllers
{
	[Area("admin")]
	public class CategoryController : Controller
	{
		// host/admin/Category/Index
		public IActionResult Index()
		{
			return View();
		}
	}
}
