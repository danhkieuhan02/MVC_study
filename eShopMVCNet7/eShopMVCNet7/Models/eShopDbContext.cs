using Microsoft.EntityFrameworkCore;

namespace eShopMVCNet7.Models
{
	public class eShopDbContext : DbContext
	{
		public DbSet<AppUser> AppUser { get; set; }
		public DbSet<AppOrder> AppOrder { get; set; }
		public DbSet<AppProduct> AppProducts { get; set; }
		public DbSet<AppCategory> AppCategories { get; set; }
		public DbSet<AppOrderDetail> AppOrderDetails { get; set; }
		public DbSet<AppProductImg> AppProductImagines { get; set; }

		public eShopDbContext(DbContextOptions options) : base(options)
		{

		}
		/*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connection = "Server=DESKTOP-6NAGO5F\\SQLEXPRESS02;Database=RazorPage_Study;Trusted_Connection=True;Encrypt=False";
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer(connection);
		}*/
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//base.OnModelCreating(modelBuilder); //gọi đến prarents
			modelBuilder.Entity<AppCategory>()
						.Property(c => c.Name)
						.HasMaxLength(200);
			modelBuilder.Entity<AppCategory>()
						.Property(c=>c.Slug)
						.HasMaxLength(200);
		}
	}
}
