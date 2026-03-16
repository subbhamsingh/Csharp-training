using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace TestWebApi.Models
{
    public class EmployeeTask
    {
        [Required(ErrorMessage = "Id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Id must be a positive integer.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MinLength(1, ErrorMessage = "Title cannot be empty")]
        [MaxLength(50, ErrorMessage = "Title cannot be longer than 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Title can only contain letters and numbers, and spaces")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MinLength(1, ErrorMessage = "Description cannot be empty")]
        [MaxLength(200, ErrorMessage = "Description cannot be longer than 200 characters")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Description can only contain letters and numbers, and spaces")]
        public string Author { get; set; }

        [Required(ErrorMessage = "AssignedTo is required")]
        [MinLength(1, ErrorMessage = "AssignedTo cannot be empty")]
        [MaxLength(30, ErrorMessage = "AssignedTo cannot be longer than 30 characters")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "AssignedTo can only contain letters, and spaces")]
        public string AssignedTo { get; set; }

        public DateTime CreatedDate { get; private set; } =  DateTime.UtcNow;

        [Required(ErrorMessage = "Status is required")]
        public Status Status { get; set; }
    }

    public enum Status
    {
        Pending,
        InProgress,
        Completed
    }
}
