using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BattleCats.BusinessLogic.Structure
{
    /// <summary>
    /// Сервис генерации JWT-токенов.
    /// 
    /// Токен содержит claims (userId, userName, role), подписан HMAC-SHA256 секретом из JwtSettings.
    /// Срок жизни токена — JwtSettings.ExpireMinutes (60 мин по умолчанию).
    /// 
    /// Используется в AuthActions после успешной валидации логина.
    /// </summary>
    public class TokenService
    {
        public TokenService() { }

        public string GenerateToken(int userId, string userName, string role)
        {
            // 1. Симметричный ключ из секрета
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 2. Claims = данные, которые попадают в Payload токена
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, role)   // ← роль для [Authorize(Roles="...")]
            };

            // 3. Собираем токен
            var token = new JwtSecurityToken(
                issuer: JwtSettings.Issuer,
                audience: JwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(JwtSettings.ExpireMinutes),
                signingCredentials: creds);

            // 4. Сериализуем в строку формата Header.Payload.Signature
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}