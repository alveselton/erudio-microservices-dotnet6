using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestWithAspNet.ProductAPI.Config;
using RestWithAspNet.ProductAPI.Model.Context;
using RestWithAspNet.ProductAPI.Repository;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];

builder.Services
    .AddDbContext<MySQLContext>(options => options
    .UseMySql(connection, new MySqlServerVersion(new Version(8,0,27))));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
