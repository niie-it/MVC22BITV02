using Microsoft.EntityFrameworkCore;

namespace Lab06.Models
{
	public class MyDbContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Loai> Loais { get; set; }
		public DbSet<HangHoa> HangHoas { get; set; }

		public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
	}
}
