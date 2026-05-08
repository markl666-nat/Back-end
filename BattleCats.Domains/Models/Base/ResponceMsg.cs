namespace BattleCats.Domains.Models.Base
{
    /// <summary>
    /// Простой ответ от BusinessLogic для операций, где не нужен Id.
    /// Аналог ActionResponse, но с именем как у препода (для 1-в-1 совместимости).
    /// 
    /// Используется в OrderAction.UpdateOrderAction/DeleteOrderAction.
    /// </summary>
    public class ResponceMsg
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}