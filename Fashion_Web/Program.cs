using Fashion_Web.Models;
using Microsoft.EntityFrameworkCore;
using Fashion_Web.Services;
using Fashion_Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var connectionString = builder.Configuration.GetConnectionString("MyDataBase");
builder.Services.AddDbContext<QLBanDoThoiTrangContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddAuthentication("MyCookieAuthentication")
    .AddCookie("MyCookieAuthentication", options =>
    {
        options.LoginPath = "/acc/dang-nhap"; 
        options.LogoutPath = "/Home/Index";
        options.AccessDeniedPath = "/Home/Home";
        options.SlidingExpiration = true;
    });
    

// Add Authorization
builder.Services.AddAuthorization();


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Thời gian session tồn tại
    options.Cookie.HttpOnly = true;                  // Bảo mật cookie
    options.Cookie.IsEssential = true;               // Bắt buộc với GDPR
});

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

app.UseSession();


// Add Authentication and Authorization middleware
app.UseAuthentication(); 
app.UseAuthorization();
app.UseMiddleware<RoleCheckMiddleware>();

/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}/{id?}");*/

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Home}/{id?}");
});
app.UseRouting();
app.Run();
