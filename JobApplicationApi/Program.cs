using Microsoft.EntityFrameworkCore;
using JobApplicationApi.IServices;
using JobApplicationApi.Models;
using JobApplicationApi.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Temp
builder.Services.AddHttpClient(); //Work with Http client.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<APICoreDBContext>(x => x.UseSqlServer(connectionString)); // check dependency Injection
builder.Services.AddScoped<ICandidateService, CandidateService>();
//builder.Services.AddScoped<ICandidateService, MokeCandidateRepository>();
//Temp

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
app.UseCors();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
//app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
