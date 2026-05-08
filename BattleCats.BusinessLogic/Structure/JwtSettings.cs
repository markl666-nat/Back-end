namespace BattleCats.BusinessLogic.Structure
{
    /// <summary>
    /// Константы для генерации и проверки JWT-токенов.
    /// 
    /// В продакшене эти значения должны храниться в User Secrets / env-переменных,
    /// а не в коде. Для учебного курсового проекта оставляем как у препода — в const.
    /// 
    /// SecretKey — минимум 32 символа (требование HMAC-SHA256).
    /// </summary>
    public static class JwtSettings
    {
        public const string Issuer = "BattleCatsApi";
        public const string Audience = "BattleCatsClients";
        public const string SecretKey = "tw_curs2026_super_secret_min_32_caractere!";
        public const int ExpireMinutes = 60;
    }
}