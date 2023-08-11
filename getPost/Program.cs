using ProductAPIVS.Models;
using Microsoft.EntityFrameworkCore
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

protected override void OnConfiguring(DbContextOptionBuilder optionBuilder)
{
    if(!optionBuilder.IsConfigured)
    {

    }
}
builder.Services.AddDbContext<Lear_DBContext>(options=>{
options.UseSqlServer(builder.configuration.GetConnectionString("constring") )

});