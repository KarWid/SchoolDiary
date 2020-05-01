namespace SchoolDiary.Api.V1.Controllers
{
    using System;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SchoolDiary.Api.Services;
    using SchoolDiary.Common.Managers;

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController, ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly ITokenService _tokenService;

        public UserController(IUserManager userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpGet("authenticate")]
        public IActionResult Authenticate(string userName, string password)
        {
            var user = _userManager.Authenticate(userName, password);
            user.Token = _tokenService.GenerateNewToken(user);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(user);
        }

        [HttpGet("get")]
        public IActionResult Get(Guid id)
        {
            var result = _userManager.Get(id);

            return Ok(result);
        }
    }
}