using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using PetshopApi.Models;
using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddDbContext<PetshopContext>(opt =>
    opt.UseInMemoryDatabase("PetshopList"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapControllers();
app.MapRazorPages();

app.Run();
