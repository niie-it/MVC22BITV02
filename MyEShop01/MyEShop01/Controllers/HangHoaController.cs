using Microsoft.AspNetCore.Mvc;
using MyEShop01.Entities;
using MyEShop01.Models;

namespace MyEShop01.Controllers
{
	public class HangHoaController : Controller
	{
		private readonly MyEshopContext _context;

		public HangHoaController(MyEshopContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var data = _context.HangHoas
				.Select(p => new HangHoaVM
				{
					Id = p.Id,
					TenHH = p.TenHh,
					DonGia = p.DonGia ?? 0,
					Hinh = p.Hinh
				});
			return View(data.ToList());
		}
	}
}
