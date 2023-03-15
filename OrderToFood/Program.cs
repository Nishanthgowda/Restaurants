using Microsoft.EntityFrameworkCore;
using Resturant.Data;


var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
     .AddJsonFile($"appsettings.json");

var config = configuration.Build();
var connectionString = config.GetConnectionString("OdeToFoodDb");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IResturantData,InMemoryData>();
builder.Services.AddDbContextPool<OdeToFoodDbContext>(options => options.UseSqlServer(connectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
