using PuzzleBox.Services;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PuzzleBox API", Version = "v1" });
});

// Register your custom services (e.g., IPuzzleService)
builder.Services.AddScoped<IPuzzleService, PuzzleService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://cyber-mauve.vercel.app")
              .AllowAnyHeader()
              .AllowAnyMethod(); // <-- Frontend dev server
    });
});
var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Maps attribute-routed controllers like PuzzleController

var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Urls.Add($"http://0.0.0.0:{port}");

app.Run();

public partial class Program { }