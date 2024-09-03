using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;
using WebRedisEx.Context;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();


// 配置Redis連線
builder.Services.AddSingleton<IConnectionMultiplexer>(c =>
{
    var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("RedisConn"), true);
    var redis = ConnectionMultiplexer.Connect(configuration);
    //var options = new ConfigurationOptions
    //{
    //    EndPoints = { "localhost:5001" },
    //    //Password = "your_password_here",
    //    ConnectTimeout = 5000, // 設置超時時間
    //    SyncTimeout = 5000,    // 設置同步超時時間
    //    AllowAdmin = true,     // 允許執行admin 命令
    //    AbortOnConnectFail = false // 連線失敗是否會中止
    //};
    //var redis = ConnectionMultiplexer.Connect(options);


    return redis;
});

//builder.Services.AddSingleton<IDatabase>(c =>
//    {
//        var redis = ConnectionMultiplexer.Connect("localhost");
//        return redis.GetDatabase();
//    }
//);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("localDB")));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
