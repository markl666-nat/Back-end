namespace BattleCats.Domain.Models.Base
{
    /// <summary>
    /// Стандартная обёртка ответа для операций Create/Update/Delete.
    /// Аналог ResponceMsg из эталонного проекта (имя сохранено, но "Response" — корректнее).
    /// </summary>
    public class ActionResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}