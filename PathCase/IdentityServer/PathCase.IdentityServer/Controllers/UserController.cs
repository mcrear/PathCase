using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using PathCase.IdentityServer.Dtos;
using PathCase.IdentityServer.Models;
using PathCase.Shared.Shared.Dtos;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace PathCase.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignupDto signup)
        {
            var user = new ApplicationUser
            {
                UserName = signup.UserName,
                Email = signup.Email
            };

            var res = await _userManager.CreateAsync(user, signup.Password);
            if (!res.Succeeded)
                return BadRequest(Response<NoContent>.Fail(res.Errors.Select(x => x.Description).ToList(), 400));
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            if (userClaim == null)
                return BadRequest();

            var user = await _userManager.FindByIdAsync(userClaim.Value);
            if (user == null)
                return NotFound();

            return Ok(new ApplicationUser { Id = user.Id, UserName = user.UserName, Email = user.Email });

        }
    }
}
