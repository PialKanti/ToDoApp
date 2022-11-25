using Microsoft.EntityFrameworkCore;
using ToDoApp.Entities;
using ToDoApp.Utils;

namespace ToDoApp.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }

        public DbSet<ToDoItem> ToDoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>()
                .HasData(
                    new ToDoItem
                    {
                        Id = 1,
                        Name = "Task 1",
                        Description = "This is Task 1.",
                        Place = "Dhaka",
                        CreatedTimestamp = CommonUtils.GetTimestamp(DateTime.UtcNow),
                        ExpiryTimestamp = CommonUtils.GetTimestamp(new DateTime(2022, 11, 22, 14, 0, 0).ToUniversalTime()),
                    },
                    new ToDoItem
                    {
                        Id = 2,
                        Name = "Task 2",
                        Description = "This is Task 2.",
                        Place = "Dhaka",
                        CreatedTimestamp = CommonUtils.GetTimestamp(DateTime.UtcNow),
                        ExpiryTimestamp = CommonUtils.GetTimestamp(new DateTime(2022, 11, 22, 20, 0, 0).ToUniversalTime())
                    },
                    new ToDoItem
                    {
                        Id = 3,
                        Name = "Task 3",
                        Description = "This is Task 2.",
                        Place = "Khulna",
                        CreatedTimestamp = CommonUtils.GetTimestamp(DateTime.UtcNow),
                        ExpiryTimestamp = CommonUtils.GetTimestamp(new DateTime(2022, 11, 22, 5, 0, 0).ToUniversalTime())
                    });
        }
    }
}
