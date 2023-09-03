using backendCSharp.Controllers;
using backendCSharp.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ColaboradorBusiness>();
builder.Services.AddDbContext<ColaboradorDbContext>(option => {
    option.UseMySql(
        "server=localhost; database=test; user=root; password=12345678",
        new MySqlServerVersion(new Version(8, 0, 33))
    );
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
