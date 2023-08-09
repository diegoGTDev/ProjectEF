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

app.Run();
