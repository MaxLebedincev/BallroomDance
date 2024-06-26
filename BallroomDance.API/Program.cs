using BallroomDance.API;
using BallroomDance.API.DAL;
using BallroomDance.API.DAL.Repositories;
using BallroomDance.API.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using BallroomDance.API.Service.Registeration;
using BallroomDance.API.Service;

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

builder.Services.AddUnitOfWork();

builder.Services.AddCustomRepository<TypeBallroomDance, TypeBallroomDanceRepository>();
builder.Services.AddCustomRepository<RussiaTrainerBallroomDance, RussiaTrainerBallroomDanceRepository>();
builder.Services.AddCustomRepository<DanceGroup, DanceGroupRepository>();
builder.Services.AddCustomRepository<ServerFile, ServerFileRepository>();
builder.Services.AddCustomRepository<MemberDanceGroup, MemberDanceGroupRepository>();
builder.Services.AddCustomRepository<UserRole, UserRoleRepository>();
builder.Services.AddCustomRepository<User, UserRepository>();

builder.Services.AddAuthentication(builder.Configuration);

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthorization();

builder.Services.AddExceptionHandler<ExceptionHandler>();

var app = builder.Build();

app.UseExceptionHandler(_ => { });

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

app.UseRouting();

app.UseCors(options => options
    .WithOrigins(new[] { "http://localhost:3000", "http://localhost:8080" })
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
