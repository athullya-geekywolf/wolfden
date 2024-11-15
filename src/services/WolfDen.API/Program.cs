using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using sib_api_v3_sdk.Client;

using WolfDen.Application.Requests.Commands.Employees.AddEmployee;
using WolfDen.Application.Requests.Commands.Employees.AdminUpdateEmployee;
using WolfDen.Application.Requests.Commands.Employees.EmployeeUpdateEmployee;
using WolfDen.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
Configuration.Default.ApiKey.Add("api-key", builder.Configuration["BrevoApi:ApiKey"]);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<WolfDenContext>(x =>
{
    x.UseSqlServer(connectionString);

});
builder.Services.AddScoped<WolfDenContext>();
builder.Services.AddMediatR(x => {
    x.RegisterServicesFromAssembly(Assembly.Load("WolfDen.Application"));
});



builder.Services.AddMediatR(x =>
{
    x.RegisterServicesFromAssembly(Assembly.Load("WolfDen.Application"));

});

builder.Services.AddScoped<AdminUpdateEmployeeValidator>();
builder.Services.AddScoped<CreateEmployeeValidator>();
builder.Services.AddScoped<EmployeeUpdateEmployeeValidator>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
