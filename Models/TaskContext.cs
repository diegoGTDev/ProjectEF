using Microsoft.EntityFrameworkCore;

namespace ProjectEF{
    public class TaskContext : DbContext{
        public DbSet<Category> Categorys {get;set;}
        public DbSet<Task> Tasks {get;set;}

        public TaskContext(DbContextOptions<TaskContext> options) : base (options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Category>(category =>{
                category.ToTable("Category");
                category.HasKey(p => p.CategoryID);
                category.Property(p => p.name).IsRequired().HasMaxLength(100);
                category.Property(p => p.description);
                category.Property(p => p.weight);
            });
            modelBuilder.Entity<Task>(task =>{
                task.ToTable("Task");
                task.HasKey(p => p.TaskID);
                task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryID);
                task.Property(p => p.Title).IsRequired().HasMaxLength(200);
                task.Property(p => p.Description);
                task.Property(p => p.TaskPriority).IsRequired();
                task.Property(p => p.CreationDate).IsRequired();
                task.Ignore(p => p.Resume);
               
            });
        }
    }
}