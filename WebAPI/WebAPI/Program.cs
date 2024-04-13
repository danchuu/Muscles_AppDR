using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services;
using System.Net;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<MusclesDBContext>();

builder.Services.AddDbContext<MusclesDBContext>(options =>
{
    // Configure DbContext to log SQL commands
    options.UseSqlServer(builder.Configuration.GetConnectionString("Server=DESKTOP-PTKBD3O\\SQLEXPRESS01;Database=MusclesDB;Trusted_Connection=True;TrustServerCertificate=True;"))
           .LogTo(Console.WriteLine, LogLevel.Information); // Log to console
});

builder.Services.AddControllers().AddJsonOptions(options =>
{

    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
