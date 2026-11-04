using CICD.Application.Interfaces;
using CICD.Infrastructure.Data;
using CICD.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddSingleton(
    new SqlConnectionFactory(connectionString));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();



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
