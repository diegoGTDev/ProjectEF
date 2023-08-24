using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectEF;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TaskContext>(
//     options => options.UseInMemoryDatabase("TaskDB")
// );
// builder.Services.AddSqlServer<TaskContext>("Data source=DESKTOP-17OBIDL\\SQLEXPRESS;database=TasksDB;trusted_connection=true;TrustServerCertificate=True;");
builder.Services.AddSqlServer<TaskContext>(builder.Configuration.GetConnectionString("TasksContext"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconnection", async ([FromServices] TaskContext _context) =>{
    _context.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + _context.Database.IsInMemory());
});
app.MapGet("/api/task", async ([FromServices] TaskContext _context) =>{
    return Results.Ok(_context.Tasks.Include(p=> p.Category).Where(p=> p.TaskPriority == Priority.Low));
});
app.MapGet("/getCategories", async ([FromServices] TaskContext _context) =>{
    return Results.Ok("Hi");
});

//AddTask
app.MapPost("/api/task", async ([FromServices] TaskContext _context, [FromBody] ProjectEF.Task task) =>
{
    task.TaskID = Guid.NewGuid();
    task.CreationDate = DateTime.Now;
    await _context.Tasks.AddAsync(task);
    //Otra manera
    // await _context.AddAsync(task);
    await _context.SaveChangesAsync();

});

app.MapDelete("/api/task/{id}", async ([FromServices] TaskContext _context, [FromRoute] Guid id) =>
{
    var tareaActual = _context.Tasks.Find(id);

    if (tareaActual != null)
    {
        _context.Remove(tareaActual);
        await _context.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound("nel");
});

/*app.MapPut("/api/task", async ([FromServices] TaskContext _context, [FromRoute] ProjectEF.Task task) =>
{
    var taskToUpdate = await _context.Tasks.FindAsync(task.TaskID);
    if (taskToUpdate == null)
    {
        return Results.NotFound("Task not found");
    }
    taskToUpdate.Title = task.Title;
    taskToUpdate.Description = task.Description;
    taskToUpdate.TaskPriority = task.TaskPriority;
    taskToUpdate.IsCompleted = task.IsCompleted;
    taskToUpdate.CategoryID = task.CategoryID;
    await _context.SaveChangesAsync();
    return Results.Ok("Task updated");
});
*/

app.Run();