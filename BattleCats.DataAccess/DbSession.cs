namespace BattleCats.DataAccess
{
    /// <summary>
    /// Статический класс хранения конфигурации БД.
    /// Содержит connection strings для двух контекстов:
    /// ProductContext (товары) и UserContext (пользователи).
    /// 
    /// Оба контекста подключаются к одной и той же БД (BattleCatsDB),
    /// но с разными "логическими" пространствами таблиц:
    ///   - ProductDB управляет таблицами BattleItems, Categories, Lores и т.д.
    ///   - UserDB управляет таблицей Users.
    /// </summary>
    public static class DbSession
    {
        /// <summary>
        /// Connection strings для подключения к локальному SQL Server.
        /// При смене SQL Server (например, в production) меняйте только эти константы.
        /// </summary>
        public static class ConnectionStrings
        {
            /// <summary>Подключение для ProductContext (таблицы товаров).</summary>
            public const string ProductDB = "Server=localhost;Database=BattleCatsDB;Trusted_Connection=True;TrustServerCertificate=True";

            /// <summary>Подключение для UserContext (таблица пользователей).</summary>
            public const string UserDB = "Server=localhost;Database=BattleCatsDB;Trusted_Connection=True;TrustServerCertificate=True";
        }
    }
}