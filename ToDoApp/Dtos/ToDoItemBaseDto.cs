using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Dtos
{
    public class ToDoItemBaseDto
    {
        [Required]
        public string? Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [MaxLength(50)]
        public string Place { get; set; }
        [Required]
        public long? ExpiryTimestamp { get; set; }
    }
}
