using System.ComponentModel.DataAnnotations;    // Required for Data Validation

namespace BlogDemoASP.Models
{
    public class Blog
    {
        public int BlogId {get; set;}	// Primary Key

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title {get; set;} = string.Empty;
    }
}