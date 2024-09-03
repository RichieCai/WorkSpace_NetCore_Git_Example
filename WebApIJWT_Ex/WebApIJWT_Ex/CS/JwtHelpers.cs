using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApIJWT_Ex.CS
{
    public class JwtHelpers
    {
        private readonly IConfiguration Configuration;

        public JwtHelpers(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public string GenerateToken(string userName, int expireMinutes = 30)
        {
            var issuer = Configuration.GetValue<string>("JwtSettings:Issuer");//表示 Issuer，發送 Token 的發行者
            var signKey = Configuration.GetValue<string>("JwtSettings:SignKey");

            #region STEP1: 建立使用者的 Claims 聲明，這會是 JWT Payload 的一部分
            // Configuring "Claims" to your JWT Token
            var claims = new List<Claim>();

            // In RFC 7519 (Section#4), there are defined 7 built-in Claims, but we mostly use 2 of them.
            //claims.Add(new Claim(JwtRegisteredClaimNames.Iss, issuer));
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, userName)); // User.Identity.Name
            //claims.Add(new Claim(JwtRegisteredClaimNames.Aud, "The Audience"));//	表示 Audience，接收 Token 的觀眾
            //claims.Add(new Claim(JwtRegisteredClaimNames.Exp, DateTimeOffset.UtcNow.AddMinutes(30).ToUnixTimeSeconds().ToString()));//表示 Expiration Time，Token 的逾期時間
            //claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString())); // 必須為數字,	表示 Not Before，定義在什麼時間之前，不可用
            //claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString())); // 必須為數字 表示 Issued At，Token 的建立時間
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())); // jti  表示 JWT ID，Token 的唯一識別碼

            // The "NameId" claim is usually unnecessary.
            //claims.Add(new Claim(JwtRegisteredClaimNames.NameId, userName));//使用者識別碼

            // This Claim can be replaced by JwtRegisteredClaimNames.Sub, so it's redundant.
            //claims.Add(new Claim(ClaimTypes.Name, userName));

            // TODO: You can define your "roles" to your Claims.
            claims.Add(new Claim("roles", "Admin"));
            claims.Add(new Claim("roles", "Users"));
 
            var userClaimsIdentity = new ClaimsIdentity(claims);
            #endregion


            #region  STEP2: 取得對稱式加密 JWT Signature 的金鑰
            // Create a SymmetricSecurityKey for JWT Token signatures
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signKey));

            // HmacSha256 MUST be larger than 128 bits, so the key can't be too short. At least 16 and more characters.
            // https://stackoverflow.com/questions/47279947/idx10603-the-algorithm-hs256-requires-the-securitykey-keysize-to-be-greater
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            #endregion

            #region 建立 JWT TokenHandler 以及用於描述 JWT 的 TokenDescriptor
            // Create SecurityTokenDescriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                //Audience = issuer, // 表示 Audience，接收 Token 的觀眾
                //NotBefore = DateTime.Now, // 表示 Not Before，定義在什麼時間之前，不可用
                //IssuedAt = DateTime.Now, //表示 Issued At，Token 的建立時間
                Subject = userClaimsIdentity, //	表示 Subject，Token 的主體內容
                Expires = DateTime.Now.AddMinutes(expireMinutes),//	表示 Expiration Time，Token 的逾期時間
                SigningCredentials = signingCredentials
            };

            // Generate a JWT securityToken, than get the serialized Token result (string)
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);  // 產出所需要的 JWT Token 物件
            var serializeToken = tokenHandler.WriteToken(securityToken);  // 產出序列化的 JWT Token 字串
            #endregion

            return serializeToken;
        }
    }
}
