using Microsoft.EntityFrameworkCore;

namespace DemoApi.Models
{
	public class BankDbContext : DbContext
	{
		public DbSet<Account> Accounts { get; set; }


		public BankDbContext(DbContextOptions options) : base(options)
		{
		}

		protected BankDbContext()
		{
		}
	}
}
