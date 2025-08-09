using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyEShop01.Entities;
using MyEShop01.Helpers;
using MyEShop01.Models;

namespace MyEShop01.Controllers
{
	public class CartController : Controller
	{
		private readonly MyEshopContext _context;
		public CartController(MyEshopContext context)
		{
			_context = context;
		}

		const string MY_CART = "CART";
		public List<CartItem> CartItems
		{
			get
			{
				return HttpContext.Session.Get<List<CartItem>>(MY_CART) ?? new List<CartItem>();
			}
		}

		public IActionResult AddToCart(int Id, int Qty = 1)
		{
			var carts = CartItems;
			var cartItem = carts.SingleOrDefault(p => p.Id == Id);
			if (cartItem == null)//chưa có
			{
				var hangHoa = _context.HangHoas.SingleOrDefault(h => h.Id == Id);
				cartItem = new CartItem
				{
					Id = Id, TenHH = hangHoa.TenHh,
					DonGia = hangHoa.DonGia ?? 0,
					Hinh = hangHoa.Hinh,SoLuong = Qty
				};
				carts.Add(cartItem);
			}
			else
			{
				cartItem.SoLuong += Qty;
			}
			HttpContext.Session.Set(MY_CART, carts);
			return RedirectToAction("Index");
		}

		[Authorize]
		public IActionResult Index()
		{
			return View(CartItems);
		}
	}
}
