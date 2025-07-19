using Lab07.Data;
using Microsoft.AspNetCore.Mvc;

namespace Lab07.Controllers
{
	public class SuppilersController : Controller
	{
		private readonly MvcNiieLabContext _ctx;

		public SuppilersController(MvcNiieLabContext ctx)
		{
			_ctx = ctx;
		}

		public IActionResult Index(string TuKhoa)
		{
			var data = _ctx.Suppliers.AsQueryable();
			if (!string.IsNullOrEmpty(TuKhoa))
			{
				data = data.Where(s => s.Name.Contains(TuKhoa) || s.Phone.Contains(TuKhoa) || s.Email.Contains(TuKhoa));
			}
			return View(data.ToList());
		}
	}
}
