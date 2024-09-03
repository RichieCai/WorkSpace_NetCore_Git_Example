var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//註冊webSocket
var webSocketOptions = new WebSocketOptions
{
    //Proxy 保持連線開啟的頻率。 預設為兩分鐘
    KeepAliveInterval = TimeSpan.FromMinutes(2)
    //WebSocket 要求之允許 Origin 標頭值的清單
    //AllowedOrigins 
   
};

app.UseWebSockets(webSocketOptions);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
