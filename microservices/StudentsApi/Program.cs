using Microsoft.EntityFrameworkCore;
using StudentsApi;

const string ConnectionStringName = "StudentsDb";

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString(ConnectionStringName);

builder.Services.AddScoped<IStudentsService, StudentsService>();
builder.Services.AddDbContext<StudentsDbContext>(optionsBuilder =>
{
    optionsBuilder.UseNpgsql(connectionString);
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(settings =>
{
    settings.DocumentName = "StudentsApi";
    settings.Title = "StudentsApi v1";
    settings.Version = "v1";
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.MapGet("/", async (IStudentsService studentsService) =>
{
    return await studentsService.GetAll().ToListAsync();
});

app.Run();