using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BlogDemoASP.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BlogDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<BlogDbContext>>()))
            {
                // Look for any blogs.
                if (context.Blogs.Any())
                {
                    return; // DB has been seeded
                }
                
                context.Blogs.AddRange(
                    new Blog
                    {
                        Title = "My First Blog"
                    },
                    new Blog
                    {
                        Title = "My Second Blog"
                    }
                );
                
                context.SaveChanges();
            }
        }
    }
}
