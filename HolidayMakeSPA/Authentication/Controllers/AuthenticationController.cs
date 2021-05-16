using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using HolidayMakeSPA.Authentication.Models;
using HolidayMakeSPA.Authentication.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using HolidayMakeSPA.Authentication.Interfaces;

namespace HolidayMakeSPA.Authentication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService userService;

        public AuthenticationController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            if (claim == null)
                return Unauthorized();
            var token = await userService.GetUserAsync(new GetUserRequest { Email = claim.Value });
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost("signIn")]
        public async Task<IActionResult> SignIn(SignInRequest signInRequest)
        {
            var token = await userService.SignInAsync(signInRequest);
            if (token == null)
                return BadRequest();
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpRequest signUpRequest)
        {
            var user = await userService.SignUpAsync(signUpRequest);
            return user == null ? BadRequest() : CreatedAtAction(nameof(Get), new { }, null);
        }
    }
}