using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.Default;
using infrastructure;
using loginapiforPMS.Controllers;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;


var builder = WebApplication.CreateBuilder(args);

// Configuration
IConfiguration configuration = builder.Configuration;

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add your data access layer
builder.Services.AddTransient<IDbConnection>(provider => new SqlConnection(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IUserRepository, UserRepository>(); // Assuming UserRepository implements IUserRepository

// Add your application layer
builder.Services.AddTransient<IUserService,UserServiceBase>();

// Configure JWT (replace with your actual implementation)
builder.Services.AddSingleton<JwtHelper>(); // Or transient/scoped if needed

// Dependency Injection for controllers
builder.Services.AddTransient<AuthController>(); // Or appropriate lifetime for your controllers

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
