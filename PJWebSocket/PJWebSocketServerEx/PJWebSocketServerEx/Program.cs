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

//���UwebSocket
var webSocketOptions = new WebSocketOptions
{
    //Proxy �O���s�u�}�Ҫ��W�v�C �w�]�������
    KeepAliveInterval = TimeSpan.FromMinutes(2)
    //WebSocket �n�D�����\ Origin ���Y�Ȫ��M��
    //AllowedOrigins 
   
};

app.UseWebSockets(webSocketOptions);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
