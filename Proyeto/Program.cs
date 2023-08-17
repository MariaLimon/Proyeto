using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Proyeto.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<SisCadticContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection"));
//});

builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(20);//You can set Time   
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/LoginR/Login"; //ruta donde iniciara la aplicacion
        options.ExpireTimeSpan = TimeSpan.FromMinutes(1); //tiempo para que expire la secion
        options.AccessDeniedPath = "/Home/Privacy"; //para mostrar formulario de acceso denegado
    });

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
