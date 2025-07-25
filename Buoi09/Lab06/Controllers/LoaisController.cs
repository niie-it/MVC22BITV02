﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab06.Models;

namespace Lab06.Controllers
{
	public class LoaisController : Controller
	{
		private readonly MyDbContext _context;

		public LoaisController(MyDbContext context)
		{
			_context = context;
		}

		// GET: Loais
		public async Task<IActionResult> Index()
		{
			return View(await _context.Loais.ToListAsync());
		}

		// GET: Loais/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var loai = await _context.Loais
				.FirstOrDefaultAsync(m => m.MaLoai == id);
			if (loai == null)
			{
				return NotFound();
			}

			return View(loai);
		}

		// GET: Loais/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Loais/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("MaLoai,TenLoai,MoTa")] Loai loai, IFormFile Hinh)
		{
			if (ModelState.IsValid)
			{
				if (Hinh != null)
				{
					var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", "Loai", Hinh.FileName);
					using (var file = new FileStream(filePath, FileMode.Create))
					{
						await Hinh.CopyToAsync(file);
					}
					loai.Hinh = Hinh.FileName;
				}
				_context.Add(loai);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(loai);
		}

		// GET: Loais/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var loai = await _context.Loais.FindAsync(id);
			if (loai == null)
			{
				return NotFound();
			}
			return View(loai);
		}

		// POST: Loais/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("MaLoai,TenLoai,MoTa,Hinh")] Loai loai)
		{
			if (id != loai.MaLoai)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(loai);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!LoaiExists(loai.MaLoai))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(loai);
		}

		// GET: Loais/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var loai = await _context.Loais
				.FirstOrDefaultAsync(m => m.MaLoai == id);
			if (loai == null)
			{
				return NotFound();
			}

			return View(loai);
		}

		// POST: Loais/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var loai = await _context.Loais.FindAsync(id);
			if (loai != null)
			{
				_context.Loais.Remove(loai);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool LoaiExists(int id)
		{
			return _context.Loais.Any(e => e.MaLoai == id);
		}
	}
}
