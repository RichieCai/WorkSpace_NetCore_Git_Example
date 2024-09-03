using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using WebTestEx_Redis.Context;
using WebTestEx_Redis.Interface;
using WebTestEx_Redis.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IUserService, UserService>();



builder.Services.AddSingleton<IConnectionMultiplexer>(c =>
{

    var options = new ConfigurationOptions
    {
        EndPoints = { "localhost:5001" },
        //Password = "your_password_here",
        ConnectTimeout = 5000, // 設置超時時間
        SyncTimeout = 5000,    // 設置同步超時時間
        AllowAdmin = true,     // 允許執行admin 命令
        AbortOnConnectFail = false // 連線失敗是否會中止
    };
    var redis = ConnectionMultiplexer.Connect(options);
    
    //var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("RedisConn"), true);
    //var redis = ConnectionMultiplexer.Connect(configuration);
    return redis;
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("localDB")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
