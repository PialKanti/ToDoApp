using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Entities
{
    public class ToDoItem : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; }
        public DateTime ExpiryDateTime { get; set;}

    }
}
