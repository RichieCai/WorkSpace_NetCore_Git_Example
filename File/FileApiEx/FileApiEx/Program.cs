var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region CORS

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
//CORS 全網站寫法 法1
//builder.Services.AddCors(option => {
//    option.AddDefaultPolicy(builder => {
//        builder.WithOrigins("http://localhost:5005",
//            "http://127.0.0.1:5500", "https://127.0.0.1:5500", "http://127.0.0.1:5501", "http://localhost:8080")
//        .SetIsOriginAllowedToAllowWildcardSubdomains()//為設定子網域成為原始的來源
//         .AllowAnyHeader()//為允許所有Request Header
//         .AllowAnyMethod();//為允許所有Http Method
//    });
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5005",
            "http://127.0.0.1:5500", "https://127.0.0.1:5500", "http://127.0.0.1:5501", "http://localhost:8080");
                      });
});
builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
);


#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
#region Cors
//app.UseCors();
app.UseCors(MyAllowSpecificOrigins);
#endregion
app.MapControllers();

app.Run();
