﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoApi.Models;

namespace DemoApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountsController : ControllerBase
	{
		private readonly BankDbContext _context;

		public AccountsController(BankDbContext context)
		{
			_context = context;
		}

		// GET: api/Accounts
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
		{
			return await _context.Accounts.ToListAsync();
		}

		// GET: api/Accounts/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Account>> GetAccount(string id)
		{
			var account = await _context.Accounts.FindAsync(id);

			if (account == null)
			{
				return NotFound();
			}

			return account;
		}

		// PUT: api/Accounts/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutAccount(string id, Account account)
		{
			if (id != account.AccountNumber)
			{
				return BadRequest();
			}

			_context.Entry(account).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!AccountExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Accounts
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Account>> PostAccount(Account account)
		{
			_context.Accounts.Add(account);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (AccountExists(account.AccountNumber))
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}

			return CreatedAtAction("GetAccount", new { id = account.AccountNumber }, account);
		}

		// DELETE: api/Accounts/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAccount(string id)
		{
			var account = await _context.Accounts.FindAsync(id);
			if (account == null)
			{
				return NotFound();
			}

			_context.Accounts.Remove(account);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool AccountExists(string id)
		{
			return _context.Accounts.Any(e => e.AccountNumber == id);
		}

		[HttpPost("register")]
		public IActionResult RegisterAccount(RegisterAccount model)
		{
			if (ModelState.IsValid)
			{
				var entity = new Account
				{
					AccountNumber = model.AccountNumber,
					AccountHolder = model.AccountHolder,
					Balance = model.Balance,
					PersonalId = model.PersonalId,
					PersonIdExpireDate = model.PersonIdExpireDate,
					Phone = model.Phone
				};
				try
				{
					_context.Add(entity);
					_context.SaveChanges();
					return Ok(new
					{
						Status = "SUCCESS",
						AccountId = model.AccountNumber,
						Message = "Tạo tài khoản thành công"
					});
				}
				catch
				{
					return Ok(new
					{
						Status = "FAIL",
						Message = "Có lỗi tạo tài khoản"
					});
				}
			}
			return Ok(new
			{
				Status = "FAIL",
				Message = "Thông tin nhập liệu không hợp lệ"
			});
		}
	}
}
