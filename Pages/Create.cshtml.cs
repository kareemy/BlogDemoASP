using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlogDemoASP.Models;

namespace BlogDemoASP.Pages;

public class CreateModel : PageModel
{
    // Property for database context;
    private readonly BlogDbContext _context; // Replaces the "db" variable from before
    private readonly ILogger<CreateModel> _logger;
    // Step 1 on forms. Create property
    [BindProperty]
    public Blog Blog {get; set;} = default!;

    public CreateModel(BlogDbContext context, ILogger<CreateModel> logger)
    {
        _context = context; // Set database context - this is part 2 of dependency injection
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