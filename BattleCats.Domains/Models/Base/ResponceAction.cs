namespace BattleCats.Domains.Models.Base
{
    /// <summary>
    /// Расширенный ответ от BusinessLogic.
    /// Используется когда помимо успеха/сообщения нужно вернуть Id (после Login или Register).
    /// При успешном логине Message содержит JWT-токен, Id — userId.
    /// 
    /// Имя сохранено как у препода ("Responce" вместо "Response") для 1-в-1 совместимости.
    /// Существует параллельно с ActionResponse (тот используется для CRUD без Id).
    /// </summary>
    public class ResponceAction
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public int Id { get; set; }
    }
}