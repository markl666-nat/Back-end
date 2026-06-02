using BattleCats.BusinessLogic.Interface;
using BattleCats.Domains.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BattleCats.Api.Controller
{

    [Route("api/session")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthActions _auth;

        public AuthController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _auth = bl.GetAuthActions();
        }

        [HttpGet("status")]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok("Session is active");
        }

        [HttpPost("auth")]
        [AllowAnonymous]
        public IActionResult Auth([FromBody] UserAuthAction data)
        {
            var result = _auth.LoginActionFlow(data);

            if (!result.IsSuccess)
            {
                return Unauthorized(result.Message);
            }


            return Ok(new { token = result.Message, userId = result.Id });
        }
    }
}