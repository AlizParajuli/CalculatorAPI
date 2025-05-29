using CalculatorAPI.Interfaces;
using CalculatorAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTransient<ICalculatorService<double>, CalculatorService>();

var app = builder.Build();
app.MapControllers();
app.Run();
