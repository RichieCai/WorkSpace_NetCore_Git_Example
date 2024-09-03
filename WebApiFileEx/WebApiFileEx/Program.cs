using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddAntiforgery(options => options.HeaderName = "X-CSRF-Token");//CSRF

//var configuration = builder.Configuration;
//builder.WebHost.UseKestrel(option =>
//{
//    //option.Limits.MaxRequestLineSize = configuration.GetValue<int>("RequestMaxSizeLimit");//htttp 請求行的最大允許大小 預設8KB
//    //option.Limits.MaxRequestBufferSize = configuration.GetValue<int>("RequestMaxSizeLimit");//請求緩衝區的最大大小 預設1M
//
//    //任何請求的最大允許大小(以字元為單位),預設30,000,000 字元 大約28.6MB
//   // option.Limits.MaxRequestBodySize = configuration.GetValue<int>("RequestMaxSizeLimit");//限制請求長度
//});
//
////上傳檔案限制
//builder.Services.Configure<FormOptions>(x =>
//{
//    //x.ValueCountLimit = int.MaxValue;//表單數量件值得最大數量限制,預設1024
//   // x.MultipartBodyLengthLimit = configuration.GetValue<int>("UploadFileMaxSizeLimit");// multipart/form- data類型的大小
//});

var app = builder.Build();

var env = app.Services.GetRequiredService<IHostEnvironment>();
var uploadFolder = $@"{env.ContentRootPath}/Upload";



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors(builder =>
     builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
 ); // Configure CORS if needed

app.UseAuthorization();


app.MapControllers();

app.Run();
