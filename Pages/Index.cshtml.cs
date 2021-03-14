using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BlogDemoASP.Models;
using Microsoft.AspNetCore.Mvc.Rendering; // Required for SelectList

namespace BlogDemoASP.Pages
{
    public class IndexModel : PageModel
    {
        // Property for database context
        private readonly BlogDbContext _context; // Replaces "db" variable
        private readonly ILogger<IndexModel> _logger;
        // SelectList Property
        public SelectList BlogsDropDown {get; set;}
        // Property for list of blogs
        public List<Blog> Blogs {get; set;}
        // Property for First Blog
        public Blog FirstBlog {get; set;}
        // Property for Filtered Blog with .Where()
        public Blog FilteredBlog {get; set;}
        // Property for Blog using .Find()
        public Blog FindBlog {get; set;}

        public IndexModel(BlogDbContext context, ILogger<IndexModel> logger)
        {
            _context = context; // Set database context - this is part 2 of dependency injection
            _logger = logger;
        }

        public void OnGet()
        {
            // Connect to database (_context)
            // Retrieve all our blogs in list format
            // Assign them to our variable "Blogs"
            Blogs = _context.Blogs.ToList();

            // Populate our SelectList
            // Blogs => The list of objects we want displayed in our select list
            // "BlogId" => The property from Blogs that will represent the value. This should always be the primary key
            // "Title" => The property from Blogs that will be displayed in the drop down.
            BlogsDropDown = new SelectList(Blogs, "BlogId", "Title");
            
            // Get just the first blog and store it in our FirstBlog Property
            FirstBlog = _context.Blogs.First();

            // Use .Where() to get a blog,
            // I will select all blogs that contain the word Second in the title
            // And then return just the First from that list. Remember, if you want a single object returned
            // you need to use .First(), .FirstOrDefault(), .Single(), or .SingleOrDefault() at the end of your query
            FilteredBlog = _context.Blogs.Where(b => b.Title.Contains("Second")).First();

            // Return a Blog with .Find()
            // This is useful in a SelectList when the user selects a blog, because it is identified by the primary key
            // Useful for other Form submissions also. Usually the id (primary key) is provided by the user through a
            // bound property on a web form
            int blogId = 2; // This will not be hard-coded in a real project. Comes from user through a form
            
            FindBlog = _context.Blogs.Find(blogId);
        }
    }
}
