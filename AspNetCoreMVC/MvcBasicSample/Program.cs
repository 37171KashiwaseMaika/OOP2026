using Microsoft.EntityFrameworkCore;
using MvcBasicSample.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// DefaultConnection‚Æ‚¢‚¤–¼‘O‚ÌÚ‘±•¶š—ñ‚ğæ“¾‚·‚é 
var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Ú‘±•¶š—ñ‚ª‚ ‚è‚Ü‚¹‚ñ");

// AppDbContext‚ğ¶¬‚·‚é‚Æ‚«‚Ég—p‚·‚éSQL Server‚ÌÚ‘±İ’è‚ğ“o˜^‚·‚é 
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
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
