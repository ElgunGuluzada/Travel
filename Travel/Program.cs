using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Travel.Data;
using Travel.Entities;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager config = builder.Configuration;


// Add services to the container.
//builder.Services.AddControllersWithViews().AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
//    //options.JsonSerializerOptions.IgnoreNullValues = true;
//});

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
    options.UseSqlServer(
                options => options.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: System.TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null)
                );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Travel}/{action=Index}/{id?}");
});
app.Run();

