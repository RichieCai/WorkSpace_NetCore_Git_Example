using Microsoft.EntityFrameworkCore;
using WebRestfulApiEx.Data;
using WebRestfulApiEx.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CustomDbSampleContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SampleDBConnection"));

});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<CustomDbSampleContext>();
    context.Database.EnsureCreated();

    DbInitializer.Initialize(services);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//app.MapGet("/", () => "Hello World!");
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller}/{action}/{id?}");
app.Run();
