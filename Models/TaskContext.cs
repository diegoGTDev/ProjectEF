using Microsoft.EntityFrameworkCore;

namespace ProjectEF{
    public class TaskContext : DbContext{
        public DbSet<Category> Categorys {get;set;}
        public DbSet<Task> Tasks {get;set;}

        public TaskContext(DbContextOptions<TaskContext> options) : base (options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            List<Category> categoriesInit = new List<Category>();
            categoriesInit.Add(new Category() {CategoryID = Guid.Parse("48370ccf-8013-41a3-9495-95ba8ea416fb"), name = "Personal", description = "Personal tasks", weight = 15});
            categoriesInit.Add(new Category() {CategoryID = Guid.Parse("48370ccf-8013-41a3-9495-95ba8ea41602"), name = "Work", description = "Work tasks", weight = 50});
            modelBuilder.Entity<Category>(category =>{
                category.ToTable("Category");
                category.HasKey(p => p.CategoryID);
                category.Property(p => p.name).IsRequired().HasMaxLength(100);
                category.Property(p => p.description);
                category.Property(p => p.weight);
                category.HasData(categoriesInit);
            });
            List<Task> tasksInit = new List<Task>();
            tasksInit.Add(new Task() {TaskID = Guid.Parse("48370ccf-8013-41a3-9495-95ba8ea41601"), CategoryID = Guid.Parse("48370ccf-8013-41a3-9495-95ba8ea416fb"), Title = "Study for exam", Description = "Study Math for the sunday", TaskPriority = Priority.Low, CreationDate = DateTime.Now, IsCompleted = false});
            modelBuilder.Entity<Task>(task =>{
                task.ToTable("Task");
                task.HasKey(p => p.TaskID);
                task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryID);
                task.Property(p => p.Title).IsRequired().HasMaxLength(200);
                task.Property(p => p.Description);
                task.Property(p => p.TaskPriority).IsRequired();
                task.Property(p => p.CreationDate).IsRequired();
                task.Property(p => p.IsCompleted).IsRequired();
                task.Ignore(p => p.Resume);
                task.HasData(tasksInit);
               
            });
        }
    }
}