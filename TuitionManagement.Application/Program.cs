using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TuitionManagement.Application.HttpServices;
using TuitionManagement.BusinessLogic.Interfaces;
using TuitionManagement.BusinessLogic.Services;
using TuitionManagement.Common.DTOs;
using TuitionManagement.Data;
using TuitionManagement.Data.Models;
using TuitionManagement.Data.Seeds;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add Db Context
builder.Services.AddDbContext<ApplicationDbContext>((options) => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity
// This will add services such as user & role manager
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Tuition Management API",
        Version = "v1"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter JWT Token"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Add custom services
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IClaimsService, ClaimsService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Add Jwt Settings
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

// Add Authentication
// This is to validate the generated JWT token which is passed in the headers of each request
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            builder.Configuration["JwtSettings:SecretKey"]!))
    };
});

builder.Services.AddAuthorization();

// Add CORS policy to allow front end
builder.Services.AddCors(options => options.AddPolicy("AllowFrontend", policy =>
{
    policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyOrigin();
}));

var app = builder.Build();

// Seeding
// usually each service needs a scope to run on since seeding is running when the application is building we are creating a scope manually
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await RoleSeeder.SeedRolesAsync(roleManager);
}
;

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

// Cors must be after the HTTP request pipeline
app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
