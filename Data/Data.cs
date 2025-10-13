using Microsoft.EntityFrameworkCore;
using TodoListMinimalApi.Models;

namespace TodoListMinimalApi.Data
{
    public class TodoListDb:DbContext
    {
        public TodoListDb(DbContextOptions<TodoListDb> options):base(options){}

        public DbSet<ListItem> ListItems { get; set; }
    }
}
