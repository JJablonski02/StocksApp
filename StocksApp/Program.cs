using StocksApp;
using StocksApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddScoped<StockService>();
builder.Services.Configure<TradingOptions>(builder.Configuration.GetSection(nameof(TradingOptions)));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
