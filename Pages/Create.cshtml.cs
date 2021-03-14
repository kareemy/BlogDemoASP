using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BlogDemoASP.Models;

namespace BlogDemoASP.Pages
{
    public class CreateModel : PageModel
    {
        private readonly BlogDbContext _context; 
        private readonly ILogger<CreateModel> _logger;
        // Step 1 on forms. Create property
        [BindProperty]
        public Blog Blog {get; set;}


        public CreateModel(BlogDbContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Blogs.Add(Blog);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}