using Microsoft.Data.Entity;

namespace ToDoList
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }

    public class ToDoItem
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public bool Completed { get; set; }

    }
}
