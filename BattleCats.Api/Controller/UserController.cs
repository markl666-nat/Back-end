using BattleCats.BusinessLogic.Interface;
using BattleCats.Domains.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BattleCats.Api.Controller
{
    /// <summary>
    /// Админ-контроллер для управления пользователями.
    /// 
    /// Все эндпоинты требуют роль Admin.
    /// Защита от удаления самого себя — нельзя удалить свой аккаунт пока залогинен.
    /// </summary>
    [Route("api/user")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserActions _users;

        public UserController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _users = bl.GetUserActions();
        }

        [HttpGet("getAll")]
        public IActionResult GetAllUsers()
        {
            var users = _users.GetAllUsers();
            return Ok(users);
        }

        [HttpPut("role")]
        public IActionResult ChangeRole([FromBody] UserChangeRoleDto data)
        {
            // Защита: нельзя изменить роль самому себе (предотвращает потерю Admin)
            var currentUserId = GetCurrentUserId();
            if (currentUserId == data.Id)
            {
                return BadRequest(new { isSuccess = false, message = "You cannot change your own role." });
            }

            var result = _users.ChangeUserRole(data);
            return Ok(result);
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            // Защита: нельзя удалить самого себя
            var currentUserId = GetCurrentUserId();
            if (currentUserId == id)
            {
                return BadRequest(new { isSuccess = false, message = "You cannot delete your own account." });
            }

            var result = _users.DeleteUser(id);
            return Ok(result);
        }

        /// <summary>
        /// Достаёт ID текущего юзера из JWT-токена.
        /// </summary>
        private int GetCurrentUserId()
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            return idClaim != null && int.TryParse(idClaim.Value, out var id) ? id : 0;
        }
    }
}