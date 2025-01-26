using Application.Queries;
using Application.Queries.GetAllRawMaterials;
using Core.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()  
              .AllowAnyMethod() 
              .AllowAnyHeader(); 
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(GetAllRawMaterialsQuery).Assembly); });

var connectionString = builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetConnectionString("StockPharmaConnection");
builder.Services.AddDbContext<StockPharmaDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IRawMaterialRepository, RawMaterialRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");  
app.UseAuthorization();

app.MapControllers();

app.Run();
