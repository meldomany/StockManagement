using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Stock.Services;
using Stock.Services.IService;
using StockManagement.API.Services.AutoMapper;
using StockManagement.API.Services.HubService;
using StockManagement.DataAccess.Data;
using StockManagement.DataAccess.IRepository;
using StockManagement.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
        .WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

builder.Services.AddSignalR();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(AutoMappings).Assembly);

builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddSingleton<IHostedService, DataSeedProcess>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();


app.MapControllers();
app.MapHub<BroadcastHub>("/stock");

app.Run();
