using Application.Queries;
using Application.Queries.GetAllRawMaterials;
using Core.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(GetAllRawMaterialsQuery).Assembly); });
var connectionString = builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetConnectionString("StockPharmaConnection");
builder.Services.AddDbContext<StockPharmaDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IRawMaterialRepository, RawMaterialRepository>();

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
