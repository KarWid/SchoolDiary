namespace SchoolDiary.Api.V1.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SchoolDiary.Api.Services;
    using SchoolDiary.Common.Managers;
    using SchoolDiary.Common.Models;
    using SchoolDiary.Repositories.EntityFramework.Entities;

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController, ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : BaseController
    {
        private readonly ITokenService _tokenService;
        private readonly IUserManager _appUserManager;
        private readonly UserManager<AppUserEntity> _identityUserManager;

        public UsersController(
            UserManager<AppUserEntity> identityUserManager,
            IUserManager appUserManager,
            ITokenService tokenService)
        {
            _identityUserManager = identityUserManager;
            _appUserManager = appUserManager;
            _tokenService = tokenService;
        }

        // TODO: add authorize attribute with admin role
        [AllowAnonymous]
        [HttpPost, Route("")]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // to change to automapper
            var newUser = new AppUserEntity
            { 
                EmailConfirmed = true, // temporary solution
                Email = user.Email,
                UserName = user.UserName,
                ConcurrencyStamp = Guid.NewGuid().ToString(), // TODO: to change
                Id = Guid.NewGuid(),
            };

            var createResult = await _identityUserManager.CreateAsync(newUser, user.Password);

            // TODO: to change
            if (createResult.Succeeded)
            {
                return new JsonResult("Successfully created") { StatusCode = StatusCodes.Status201Created };
            }

            return BadRequest(createResult.Errors); // TODO: to change
        }

        [HttpPut, Route("")]
        public IActionResult Edit([FromBody] User user)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("authenticate")]
        public IActionResult Authenticate(string userName, string password)
        {
            var user = _appUserManager.Authenticate(userName, password);
            user.Token = _tokenService.GenerateNewToken(user);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(user);
        }
    }
}