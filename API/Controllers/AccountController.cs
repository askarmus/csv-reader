using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartStore.BusinessServices;
using SmartStore.DataAccess.Entity;
using SmartStore.Model;
using Microsoft.AspNetCore.Authorization;

namespace SmartStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _userService;

        public AccountController(ILogger<AccountController> logger, IUserService userService, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _userService = userService;
            _userManager = userManager;
        }

        [HttpGet("TestAuth")]
        [Authorize]
        public async Task<IActionResult> TestAuth()
        {
            return Ok("Auth works");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginRequestModel model)
        {
            var userToVerify = await _userManager.FindByNameAsync(model.Username);
            if (userToVerify != null)
            {
                if (await _userManager.CheckPasswordAsync(userToVerify, model.Password))
                {
                    var authToken = await _userService.AuthenticateAsync(model.Username, ipAddress());

                    return Ok(authToken);
                }
            }

            return BadRequest(new { message = "Username or password is incorrect" });
        }

        private string ipAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

    }
}
