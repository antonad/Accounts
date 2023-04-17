using Accounts.Api.Middleware;
using Accounts.Api.Models;
using Accounts.Api.ServiceProxies;
using Accounts.Api.ServiceProxies.Interfaces;
using Accounts.Business.Services;
using Accounts.Business.Services.Interfaces;
using Accounts.DAL;
using Accounts.Dto;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AccountsDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("Mysql"), ServerVersion.Parse("8.0.30"))
);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<IEmployeeServiceProxy, EmployeeServiceProxy>();
builder.Services.AddScoped<IPositionServiceProxy, PositionServiceProxy>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.CreateMap<EmployeeDto, EmployeeModel>().ReverseMap().PreserveReferences();
    cfg.CreateMap<PositionDto, PositionModel>().ReverseMap().PreserveReferences();
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionLogging();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
