using BallroomDanceAPI;
using BallroomDanceAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.LogTo(Console.WriteLine);

    options.UseSqlServer(builder.Configuration["AppSettings:ConnectionString"]);
});

var app = builder.Build();

app.Map("*", (IOptions<AppSettings> options) =>
{
    AppSettings _appSettings = options.Value;

    _appSettings.DirectoryFiles = $"{AppDomain.CurrentDomain.BaseDirectory}{_appSettings.DirectoryFiles}";
    
    return _appSettings;
});

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
