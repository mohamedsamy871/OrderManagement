using Microsoft.EntityFrameworkCore;
using OrderManagement.Models.DomainModels;
using OrderManagement.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
string connectionString = Environment.GetEnvironmentVariable("OrderManagement_Db", EnvironmentVariableTarget.Machine);
builder.Services.AddDbContext<DataContext>(options =>
               options.UseSqlServer(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDiscountService, DiscountService>();
builder.Services.AddScoped<ILoyalityService, LoyalityCalculationService>();
builder.Services.AddScoped<IOrderService, OrderService>();

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
