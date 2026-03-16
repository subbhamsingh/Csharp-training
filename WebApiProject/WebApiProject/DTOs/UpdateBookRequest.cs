using System.ComponentModel.DataAnnotations;

namespace WebApiProject.DTOs
{
    public class UpdateBookRequest
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Author must be between 3 and 60 characters.")]
        public string Author { get; set; }
    }
}
