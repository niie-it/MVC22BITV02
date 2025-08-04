using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyEShop01.Entities;
using MyEShop01.Models;
using System.Security.Claims;

namespace MyEShop01.Controllers
{
	public class AccountController : Controller
	{
		private readonly MyEshopContext _context;
		public AccountController(MyEshopContext context)
		{
			_context = context;
		}

		public IActionResult Login(string? ReturnUrl = null)
		{
			ViewBag.ReturnUrl = ReturnUrl;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginVM model, string? ReturnUrl = null)
		{
			var khachHang = _context.KhachHangs.SingleOrDefault(p => p.TenDangNhap == model.Username && p.MatKhau == model.Password);

			if (khachHang != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, model.Username),
					new Claim(ClaimTypes.Email, khachHang.Email),
					new Claim("UserId", khachHang.Id.ToString()),
					new Claim(ClaimTypes.Role, "Admin")//làm động, đọc DB ra
				};

				var identity = new ClaimsIdentity(claims, "MyCookieAuth");
				var principal = new ClaimsPrincipal(identity);
				await HttpContext.SignInAsync("MyCookieAuth", principal);

				if (!string.IsNullOrEmpty(ReturnUrl))
				{
					return Redirect(ReturnUrl);
				}
				return RedirectToAction("Index", "Home");
			}

			ViewBag.Error = "Sai thông tin đăng nhập!";
			ViewBag.ReturnUrl = ReturnUrl;
			return View();
		}

		[Authorize]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync("MyCookieAuth");
			return RedirectToAction("Login");
		}

		[Authorize]
		public IActionResult AccessDenied()
		{
			return View("AccessDenied");
		}
	}
}
