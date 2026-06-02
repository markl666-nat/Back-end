using BattleCats.Domains.Entities.User;

namespace BattleCats.Domains.Models.User
{
    
    public class UserListDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public DateTime DOB { get; set; }
    }

   
    public class UserChangeRoleDto
    {
        public int Id { get; set; }
        public UserRole NewRole { get; set; }
    }
}