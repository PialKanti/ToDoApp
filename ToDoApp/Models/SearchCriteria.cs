using Microsoft.AspNetCore.Mvc;

namespace ToDoApp.Models
{
    public class SearchCriteria
    {
        [FromQuery(Name= "type")]
        public int Type { get; set; }
        [FromQuery(Name = "name")]
        public string? Name { get; set; }
    }
}
