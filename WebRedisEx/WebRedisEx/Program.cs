using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;
using WebRedisEx.Context;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();


// �t�mRedis�s�u
builder.Services.AddSingleton<IConnectionMultiplexer>(c =>
{
    var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("RedisConn"), true);
    var redis = ConnectionMultiplexer.Connect(configuration);
    //var options = new ConfigurationOptions
    //{
    //    EndPoints = { "localhost:5001" },
    //    //Password = "your_password_here",
    //    ConnectTimeout = 5000, // �]�m�W�ɮɶ�
    //    SyncTimeout = 5000,    // �]�m�P�B�W�ɮɶ�
    //    AllowAdmin = true,     // ���\����admin �R�O
    //    AbortOnConnectFail = false // �s�u���ѬO�_�|����
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
