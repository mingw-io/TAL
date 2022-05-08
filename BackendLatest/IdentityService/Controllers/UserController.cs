namespace IdentityService.Controllers
{
    using IdentityService.Models;
    using IdentityService.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginParam"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] Login loginParam)
        {
            if (loginParam == null) return BadRequest();
            if (string.IsNullOrWhiteSpace(loginParam.Username)) return BadRequest();
            if (string.IsNullOrWhiteSpace(loginParam.Password)) return BadRequest();

            // NOTE: The 'password' input argument could be an MD5 hash of the plain text password.
            //       To avoid sending plain text sensitive info on the net (e.g. Internet)
            var token = _userService.Authenticate(loginParam.Username, loginParam.Password);

            if (token == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(token);
        }
    }
}
