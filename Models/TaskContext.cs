using Microsoft.EntityFrameworkCore;

namespace ProjectEF{
    public class TaskContext : DbContext{
        public DbSet<Category> Categorys {get;set;}
        public DbSet<Task> Tasks {get;set;}

        public TaskContext(DbContextOptions<TaskContext> options) : base (options) {}
    }
}