using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCatsStore.Domains.Models.Base
{
    // Исправили опечатку: Response вместо Responce
    public class ActionResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
