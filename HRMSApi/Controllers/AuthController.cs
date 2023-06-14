using HRMSApi.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.Identity;
using Repository.Repository;

namespace HRMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JWTRepository _jwtRepository;

        public AuthController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager,JWTRepository jWTRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _jwtRepository = jWTRepository;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> register(RegisterVM register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error");
            }

            ApplicationUser user = new ApplicationUser()
            {
                UserName=register.UserName,
                Email=register.Email,
                PhoneNumber=register.PhoneNumber
            };

            IdentityResult result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                return BadRequest();
            }

            ApplicationRole applicationRole = await _roleManager.FindByNameAsync("User");

            if (applicationRole == null)
            {
                applicationRole = new ApplicationRole() { Name = "User" };
                await _roleManager.CreateAsync(applicationRole);
            }

            await _userManager.AddToRoleAsync(user, applicationRole.Name);
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<ActionResult> login(LoginVM login)
        {
            var user = await GetUserByEmailOrUserName(login.EmailOrUserName);

            if (user!=null)
            {
                var token = _jwtRepository.Authenticate(user.UserName, user.PasswordHash);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }

        private async Task<ApplicationUser> GetUserByEmailOrUserName(string emailOrUserName)
        {
            return emailOrUserName.Contains("@")
                ? await _userManager.FindByEmailAsync(emailOrUserName)
                : await _userManager.FindByNameAsync(emailOrUserName);
        }
    }
}
