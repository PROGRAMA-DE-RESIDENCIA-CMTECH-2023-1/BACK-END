global using cmtech_backend.Data.Context;
global using Microsoft.EntityFrameworkCore;
using cmtech_backend.Repositories.Implementations;
using cmtech_backend.Repositories.Interfaces;
using cmtech_backend.Services.Implementations;
using cmtech_backend.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProfileRepository, ProfileRepositoryImpl>();
builder.Services.AddScoped<IProfileService, ProfileServiceImpl>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();