using Microsoft.EntityFrameworkCore;
using Travel.Data;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager config = builder.Configuration;
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
