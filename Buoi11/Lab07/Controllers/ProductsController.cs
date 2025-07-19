using Lab07.Data;
using Lab07.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab07.Controllers
{
	public class ProductsController : Controller
	{
		private readonly MvcNiieLabContext _context;

		public ProductsController(MvcNiieLabContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var data = _context.Products
						.Include(p => p.Category)
						.Include(p => p.Supplier);
			return View(data.ToList());
		}

		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "NameVn");
			ViewBag.Suppliers = new SelectList(_context.Suppliers.ToList(), "Id", "Name");
			return View();
		}

		[HttpPost]
		public IActionResult Create(Product model, IFormFile Image)
		{
			if (Image != null)
			{
				model.Image = MyTool.UploadImageToFolder(Image, "Products");
			}
			try
			{
				_context.Add(model);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "NameVn");
				ViewBag.Suppliers = new SelectList(_context.Suppliers.ToList(), "Id", "Name");
				ViewBag.Message = $"Lỗi upload file: {ex.Message}";
				return View();
			}
		}


		[HttpGet]
		public IActionResult Edit(int id)
		{
			var product = _context.Products.SingleOrDefault(p => p.Id == id);
			if (product != null)
			{
				ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "NameVn", product.CategoryId);
				ViewBag.Suppliers = new SelectList(_context.Suppliers.ToList(), "Id", "Name", product.SupplierId);
				return View(product);
			}
			return NotFound();
		}


		[HttpPost]
		public IActionResult Edit(int id, Product model, IFormFile NewImage)
		{
			var product = _context.Products.SingleOrDefault(p => p.Id == id);
			if (product != null)
			{
				if (NewImage != null)
				{
					model.Image = MyTool.UploadImageToFolder(NewImage, "Products");
				}

				try
				{
					product.Name = model.Name;
					product.Description = model.Description;
					product.CategoryId = model.CategoryId;
					product.SupplierId = model.SupplierId;
					product.UnitPrice = model.UnitPrice;
					_context.Update(product);
					_context.SaveChanges();
					return RedirectToAction("Edit", new { Id = id });
				}
				catch (Exception ex)
				{
					ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "NameVn", model.CategoryId);
					ViewBag.Suppliers = new SelectList(_context.Suppliers.ToList(), "Id", "Name", model.SupplierId);
					return View(model);
				}
			}
			return NotFound();
		}
	}
}
