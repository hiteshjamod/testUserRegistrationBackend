using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using UserRegistration.Contract;
using UserRegistration.Models;
using UserRegistration.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();

var Mybuilder = new ConfigurationBuilder();
Mybuilder.AddJsonFile("appsettings.json");
IConfiguration Configuration = Mybuilder.Build();
builder.Services.AddDbContext<UserContext>(x => x.UseSqlServer(Configuration.GetConnectionString("ConStr")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

#region Dependency Injection

builder.Services.AddScoped<IUserService, UserService>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
