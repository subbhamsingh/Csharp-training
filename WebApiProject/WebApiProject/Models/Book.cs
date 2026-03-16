using System.ComponentModel.DataAnnotations;

namespace WebApiProject.Models
{
    public class Book
    {
  
        public int Id { get; set; }

        public string Title { get; set; }

        public string  Author { get; set; }


        public string Isbn { get; set; }       
        public bool IsAvailable { get; set; }

        public DateTime CreatedAt { get;  set; } = DateTime.Now;
    }
}
