using BattleCats.BusinessLogic.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BattleCats.Domains.Models.User;

namespace BattleCats.Api.Controller
{
    [Route("api/session")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        internal IAuthActions _auth;
        public AuthController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _auth = bl.GetAuthActions();
        }


        [HttpGet("satus")]
        public IActionResult Get()
        {
            return Ok("Session is active");
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserAuthAction data)
        {
            var authStatus = _auth.LoginActionFlow(data);
            
            string token = "";
            return Ok(token);
        }
    }
}
