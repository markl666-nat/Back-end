using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCats.DataAccess
{
    /// <summary>
    /// Статический держатель connection string для всех DbContext'ов проекта.
    /// Значение присваивается один раз в Program.cs из appsettings.json.
    /// </summary>
    public class DbSession
    {
        public static string ConnectionStrings { get; set; } = string.Empty;
    }
}