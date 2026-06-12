using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TuitionManagement.BusinessLogic.Interfaces;
using TuitionManagement.BusinessLogic.Services;
using TuitionManagement.Data;
using TuitionManagement.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add Db Context
builder.Services.AddDbContext<ApplicationDbContext>((options) => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

// Add other services
builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
