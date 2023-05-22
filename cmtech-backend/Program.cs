global using cmtech_backend.Data.Context;
global using Microsoft.EntityFrameworkCore;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Repositories.Implementations;
using cmtech_backend.Repositories.Interfaces;
using cmtech_backend.Services.Implementations;
using cmtech_backend.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IRepository<User>, UserRepositoryImpl>();
builder.Services.AddScoped<IRepository<Org>, OrgRepositoryImpl>();
builder.Services.AddScoped<IRepository<Department>, DepartmentRepositoryImpl>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryImpl<>));
builder.Services.AddScoped<IProfileService, ProfileServiceImpl>();
builder.Services.AddScoped<IGroupService, GroupServiceImpl>();
builder.Services.AddScoped<ISegmentService, SegmentServiceImpl>();
builder.Services.AddScoped<IOrgService, OrgServiceImpl>();
builder.Services.AddScoped<IUserService, UserServiceImpl>();
builder.Services.AddScoped<IDepartmentService, DepartmentServiceImpl>();
builder.Services.AddScoped<ILoginService, LoginServiceImpl>();
builder.Services.AddScoped<IValidationService, ValidationServiceImpl>();

builder.Services.AddCors();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard authorization using Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("TokenConfigurations:Secret").Value!)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
