using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using AppMovie.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);

// if (builder.Environment.IsDevelopment())
// {
//     builder.Services.AddDbContext<AppMovieContext>(options =>
//         options.UseSqlite(builder.Configuration.GetConnectionString("AppMovieContext")));
// }
// else
// {
//     builder.Services.AddDbContext<AppMovieContext>(options =>
//         options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionMvcMovieContext")));
// }
builder.Services.AddDbContext<AppMovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppMovieContext") ?? throw new InvalidOperationException("Connection string 'AppMovieContext' not found.")));

builder.Services.AddDbContext<AppMovieIdentityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppMovieContext") ?? throw new InvalidOperationException("Connection string 'AppMovieContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppMovieIdentityDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

// colocamos en la linea 5:
// if (builder.Environment.IsDevelopment())
// {
//     builder.Services.AddDbContext<MvcMovieContext>(options =>
//         options.UseSqlite(builder.Configuration.GetConnectionString("MvcMovieContext")));
// }
// else
// {
//     builder.Services.AddDbContext<MvcMovieContext>(options =>
//         options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionMvcMovieContext")));
// }
//colocamos en terminal:dotnet build
//colocamos en terminal: dotnet ef migrations add PrimerMigracionSQLite
//colocamos en terminal:dotnet ef database update
//