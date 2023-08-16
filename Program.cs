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
app.MapGet("/getTasks", async ([FromServices] TaskContext _context) =>{
    return Results.Ok(_context.Tasks.Include(p=> p.Category).Where(p=> p.TaskPriority == Priority.Low));
});
app.MapGet("/getCategories", async ([FromServices] TaskContext _context) =>{
    return Results.Ok("Hi");
});

//AddTask
app.MapPost("/addTask", async ([FromServices] TaskContext _context, [FromBody] ProjectEF.Task task) =>{
    _context.Tasks.Add(task);
    await _context.SaveChangesAsync();
    return Results.Ok("Task added");
});

app.Run();
