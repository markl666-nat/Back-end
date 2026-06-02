namespace BattleCats.BusinessLogic.Structure
{
    
    public static class JwtSettings
    {
        public const string Issuer = "BattleCatsApi";
        public const string Audience = "BattleCatsClients";
        public const string SecretKey = "tw_curs2026_super_secret_min_32_caractere!";
        public const int ExpireMinutes = 60;
    }
}