global using Microsoft.EntityFrameworkCore;
global using System.ComponentModel.DataAnnotations;
using GetIt.Api.Data;
using GetIt.Api.Data.IRepositories;
using GetIt.Api.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<GetItAppContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString") ?? throw new InvalidOperationException("Connection string 'GetItAppContext' not found.")));

builder.Services.AddCors(options =>
  {
    options.AddPolicy(name: "ReactLocalhost",
        policy =>
        {
          policy.AllowAnyHeader()
          .AllowAnyMethod()
          .AllowAnyOrigin();
        });
  });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IQuizRepository, QuizRepository>();
builder.Services.AddScoped<IOptionRepository, OptionRepository>();
builder.Services.AddScoped<IResultRepository, ResultRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;
  SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("ReactLocalhost");

app.MapControllers();

app.Run();
