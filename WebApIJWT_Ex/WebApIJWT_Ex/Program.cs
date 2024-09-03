using Generally.Interfaces;
using Generally.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Text;
using WebApIJWT_Ex.CS;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


IConfiguration Configuration = builder.Configuration;
builder.Services.AddScoped<IDbConnection, SqlConnection>(serviceProvider => {
    SqlConnection conn = new SqlConnection();
    //�����s�u�r��
    conn.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
    return conn;
});
builder.Services.AddScoped<IToDoListRepository, ToDoListRepository>();

#region jwt
builder.Services.AddSingleton<JwtHelpers>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // �����ҥ��ѮɡA�^�����Y�|�]�t WWW-Authenticate ���Y�A�o�̷|��ܥ��Ѫ��Բӿ��~��]
        options.IncludeErrorDetails = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // �z�L�o���ŧi�A�N�i�H�q "sub" ���Ȩó]�w�� User.Identity.Name
            NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
            // �z�L�o���ŧi�A�N�i�H�q "roles" ���ȡA�åi�� [Authorize] �P�_����
            RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
            // �@��ڭ̳��|���� Issuer
            ValidateIssuer = true,//�O�ֵ֮o��(false ������)
            ValidIssuer = builder.Configuration.GetValue<string>("JwtSettings:Issuer"),

            // �q�`���ӻݭn���� Audience
            ValidateAudience = false,//���ǫȤ�(client)�i�H�ϥ�
            //ValidAudience = "JwtAuthDemo", // �����ҴN���ݭn��g

            // �@��ڭ̳��|���� Token �����Ĵ���
            ValidateLifetime = true,

            // �p�G Token ���]�t key �~�ݭn���ҡA�@�볣�u��ñ���Ӥw
            ValidateIssuerSigningKey = false,
            // "1234567890123456" ���ӱq IConfiguration ���o
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JwtSettings:SignKey")))

        };
    });
builder.Services.AddAuthorization();
#endregion


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//�ݦbUseHttpsRedirection�᭱
#region jwt
app.UseAuthentication();
app.UseAuthorization();
#endregion
app.MapControllers();


//jwt �otoken
app.MapPost("/signin", (LoginViewModel login, JwtHelpers jwt) =>
{
    if (ValidateUser(login))
    {
        var token = jwt.GenerateToken(login.Username);
        return Results.Ok(new { token });
    }
    else
    {
        return Results.BadRequest();
    }
})
    .WithName("SignIn")
    .AllowAnonymous();

//���o JWT Token �����Ҧ� Claims ��T (�ݵn�J�~��ϥ�)
app.MapGet("/claims", (ClaimsPrincipal user) =>
{
    return Results.Ok(user.Claims.Select(p => new { p.Type, p.Value }));
})
    .WithName("Claims")
    .RequireAuthorization();

//���o JWT Token �����ϥΪ̦W�� (�ݵn�J�~��ϥ�)
app.MapGet("/username", (ClaimsPrincipal user) =>
{
    return Results.Ok(user.Identity?.Name);
})
    .WithName("Username")
    .RequireAuthorization();

//���o JWT Token ���� JWT ID (�ݵn�J�~��ϥ�)
app.MapGet("/jwtid", (ClaimsPrincipal user) =>
{
    return Results.Ok(user.Claims.FirstOrDefault(p => p.Type == "jti")?.Value);
})
    .WithName("JwtId")
    .RequireAuthorization();

//���o�ϥΪ̬O�_�֦��S�w���� (�ݵn�J�~��ϥ�)
app.MapGet("/isInRole", (ClaimsPrincipal user, string name) =>
{
    return Results.Ok(user.IsInRole(name));
})
    .WithName("IsInRole")
    .RequireAuthorization();


bool ValidateUser(LoginViewModel login)
{
    return true;
}
app.Run();





//�ҫ����O (�Ψӵn�J�ɪ��ҫ�ô��)
record LoginViewModel(string Username, string Password);