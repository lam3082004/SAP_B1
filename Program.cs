using Microsoft.EntityFrameworkCore;
using item_management.Data;
using item_management.Service;
using item_management.Repository;
using item_management.Controller; 
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);


// Đăng ký OWHS_Service
// builder.Services.AddScoped<OWHS_Service>();



// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddScoped<IOITM_Service, OITM_Service>();
builder.Services.AddScoped<IOITW_Service, OITW_Service>();
builder.Services.AddScoped<IOWHS_Service, OWHS_Service>();
builder.Services.AddScoped<IOUGP_Service, OUGP_Service>();
builder.Services.AddScoped<IOUOM_Service, OUOM_Service>();
builder.Services.AddScoped<IUGP1_Service, UGP1_Service>();
builder.Services.AddScoped<IUGP1Repository, UGP1Repository>();
builder.Services.AddScoped<IOUOM_Repository, OUOM_Repository>();
builder.Services.AddScoped<IOUGP_Repository, OUGP_Repository>();
builder.Services.AddScoped<IOWHS_Repository, OWHS_Repository>();
builder.Services.AddScoped<IOITW_Repository, OITW_Repository>();
builder.Services.AddScoped<IOITM_Repository, OITM_Repository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Server=(localdb)\\mssqllocaldb;Database=item_management;Trusted_Connection=True;MultipleActiveResultSets=true
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};



app.MapControllers();
app.Run();

