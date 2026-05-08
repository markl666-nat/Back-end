using BattleCats.BusinessLogic.Interface;
using BattleCats.Domains.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BattleCats.Api.Controller
{
    /// <summary>
    /// Контроллер регистрации новых пользователей.
    /// 
    /// POST /api/reg — принимает UserRegisterDto, создаёт юзера с ролью User
    /// и захешированным паролем. Эндпоинт публичный ([AllowAnonymous]).
    /// </summary>
    [Route("api/reg")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterActions _userReg;

        public RegisterController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _userReg = bl.GetRegisterActions();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register([FromBody] UserRegisterDto uRegData)
        {
            var result = _userReg.RegisterActionFlow(uRegData);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(new { id = result.Id, message = result.Message });
        }
    }
}