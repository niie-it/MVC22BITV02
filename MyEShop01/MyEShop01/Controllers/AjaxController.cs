using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEShop01.Entities;
using MyEShop01.Models;

namespace MyEShop01.Controllers
{
	public class AjaxController : Controller
	{
		private readonly MyEshopContext _context;

		public AjaxController(MyEshopContext context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult Search()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Search(string keyword)
		{
			var data = _context.HangHoas
				.Include(p => p.MaLoaiNavigation)
				.Where(p => p.TenHh.Contains(keyword))
				.Select(p => new KetQuaTimKiemVM
				{
					TenHh = p.TenHh,
					MaHh = p.Id,
					DonGia = p.DonGia.Value,
					Hinh = p.Hinh,
					Loai = p.MaLoaiNavigation.TenLoai,
					NgaySX = p.NgaySx
				})
				.ToList();
			return PartialView("TimKiemPartial", data);
		}
	}
}
