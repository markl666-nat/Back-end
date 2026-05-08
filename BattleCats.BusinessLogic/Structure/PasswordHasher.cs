using System.Security.Cryptography;
using System.Text;

namespace BattleCats.BusinessLogic.Structure
{
    /// <summary>
    /// Хешер паролей. Использует MD5 + фиксированный суффикс ("соль").
    /// 
    /// Соль защищает от радужных таблиц: если БД утечёт, готовые публичные MD5
    /// для тривиальных паролей (например, "qwerty" → d8578edf8458ce06fbc5bb76a58c5ca4)
    /// не совпадут, потому что реальный input для MD5 — это "qwerty" + suffix.
    /// 
    /// В продакшене вместо MD5 нужен BCrypt/Argon2 (медленные, защищают от brute-force).
    /// MD5 для курсового — учебная упрощённая версия как у препода.
    /// </summary>
    public static class PasswordHasher
    {
        private const string PasswordSuffix = "tw_curs2026";

        public static string Hash(string password)
        {
            var input = password + PasswordSuffix;
            var bytes = Encoding.UTF8.GetBytes(input);
            var hashBytes = MD5.HashData(bytes);

            var sb = new StringBuilder();
            foreach (var b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}