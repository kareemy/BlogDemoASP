using Microsoft.EntityFrameworkCore;

namespace BlogDemoASP.Models
{
	public class BlogDbContext : DbContext
	{
		public BlogDbContext (DbContextOptions<BlogDbContext> options)
			: base(options)
		{
		}
		public DbSet<Blog> Blogs {get; set;} = default!;
	}
}