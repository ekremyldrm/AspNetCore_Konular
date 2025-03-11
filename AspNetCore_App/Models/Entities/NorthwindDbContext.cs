using Microsoft.EntityFrameworkCore;

namespace AspNetCore_App.Models.Entities
{
	public class NorthwindDbContext : DbContext
	{
		public NorthwindDbContext(DbContextOptions options)
			: base(options)
		{
		}

		public DbSet<Product> Products { get; set; }
	}
}
