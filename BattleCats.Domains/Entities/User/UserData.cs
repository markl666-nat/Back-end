using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BattleCats.Domain.Enums;

namespace BattleCats.Domain.Entities.User
{
    /// <summary>
    /// Сущность пользователя сайта Cat Base Shop.
    /// Хранит логин, email, пароль (БУДЕТ хэширован в Лабе 5).
    /// Поле Role будет добавлено в Лабе 5 для разграничения прав (User/Admin).
    /// </summary>
    public class UserData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Email { get; set; } = string.Empty;

        public string? Contacts { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        public GenderTypes Gender { get; set; } = GenderTypes.NotSpecified;
    }
}