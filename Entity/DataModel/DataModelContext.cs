using Microsoft.EntityFrameworkCore;

namespace Entity.DataModel
{
	public partial class DataModelContext : DbContext
	{
		public DataModelContext(DbContextOptions<DataModelContext> options)
			: base(options)
		{ }

		public virtual DbSet<Blog> Blog { get; set; }

		protected override void OnModelCreating(ModelBuilder modelbuilder)
		{
			modelbuilder.Entity<Blog>().HasKey(c => new { c.Id });
		}
	}
}
