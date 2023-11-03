using api_flora.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

if(allowedOrigins != null)
{
    builder.Services.AddCors(options => {
        options.AddPolicy("api-cors", policy => {
            policy.WithOrigins(allowedOrigins)
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });
}

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if(!string.IsNullOrEmpty(connectionString))
{
    builder.Services.AddDbContext<DataContext>(options => {
        options.UseMySQL(
            connectionString
        );
    });
}

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

app.UseCors("api-cors");

app.Run();