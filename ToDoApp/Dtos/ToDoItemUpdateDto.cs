using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Dtos
{
    public class ToDoItemUpdateDto : ToDoItemBaseDto
    {
        [Required]
        public int? Id { get; set; }
        public bool IsCompleted { get; set; }
    }
}
