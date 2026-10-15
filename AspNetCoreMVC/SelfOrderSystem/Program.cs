using Microsoft.EntityFrameworkCore;
using SelfOrderSystem.Data;
using SelfOrderSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 追加
builder.Services.AddDbContext<AppDbContext>(
        options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
/////////

builder.Services.AddDistributedMemoryCache(); // Session の保存領域としてアプリのメモリを使う
builder.Services.AddSession(options => // Session 機能を登録
{
    options.IdleTimeout = TimeSpan.FromHours(2);    // 2 時間操作がなければ期限切れ
    options.Cookie.HttpOnly = true;                 // JavaScript からSession ID を読めないようにする
    options.Cookie.IsEssential = true;              // Session ID 用Cookie を必須Cookie として扱う
});
builder.Services.AddHttpContextAccessor(); // Controller 以外のクラスからHttpContext を取得できるようにする
builder.Services.AddScoped<CartService>(); // CartService をDI へ登録しControllerで受け取れるようにする

var app = builder.Build();

// 追加
if (app.Environment.IsDevelopment()) {
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await SeedData.InitializeAsync(db);
}
/////////
///
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 追加
app.UseSession(); // このリクエストでSession を使えるようにする
/////////

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
