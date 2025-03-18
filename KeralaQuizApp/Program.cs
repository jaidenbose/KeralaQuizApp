var builder = WebApplication.CreateBuilder(args);

// Add services to enable MVC and views
builder.Services.AddControllersWithViews();

// Enable session management
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session will expire after 30 mins of inactivity
    options.Cookie.HttpOnly = true; // Ensures security by making the session cookie HTTP-only
    options.Cookie.IsEssential = true; // Ensures session works even with strict cookie settings
});

var app = builder.Build();

// Middleware for error handling and security
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession(); // Enable session usage

app.UseRouting();

app.UseAuthorization();

// Define default route (HomeController -> Index)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
