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
//    //option.Limits.MaxRequestLineSize = configuration.GetValue<int>("RequestMaxSizeLimit");//htttp �ШD�檺�̤j���\�j�p �w�]8KB
//    //option.Limits.MaxRequestBufferSize = configuration.GetValue<int>("RequestMaxSizeLimit");//�ШD�w�İϪ��̤j�j�p �w�]1M
//
//    //����ШD���̤j���\�j�p(�H�r�������),�w�]30,000,000 �r�� �j��28.6MB
//   // option.Limits.MaxRequestBodySize = configuration.GetValue<int>("RequestMaxSizeLimit");//����ШD����
//});
//
////�W���ɮ׭���
//builder.Services.Configure<FormOptions>(x =>
//{
//    //x.ValueCountLimit = int.MaxValue;//���ƶq��ȱo�̤j�ƶq����,�w�]1024
//   // x.MultipartBodyLengthLimit = configuration.GetValue<int>("UploadFileMaxSizeLimit");// multipart/form- data�������j�p
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
