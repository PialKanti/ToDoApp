using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToDoApp.Entities
{
    public class ToDoItem : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [MaxLength(200)]
        public string Place { get; set; }
        public bool IsCompleted { get; set; }
        public long CreatedTimestamp { get; set; }
        [Required]
        public long? ExpiryTimestamp { get; set;}
    }
}
