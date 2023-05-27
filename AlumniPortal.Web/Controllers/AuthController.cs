using AlumniPortal.Domain.Auth;
using AlumniPortal.Domain.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AlumniPortal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly PasswordHasher<string> _passwordHaser;
        public AuthController(UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager) { 
            _userManager = userManager;
            _roleManager = roleManager;
            _passwordHaser = new PasswordHasher<string>();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            if (registerRequestDto == null)
            {
                return NotFound();
            }
            var identityUser = new ApplicationUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username,
                PasswordHash = _passwordHaser.HashPassword(null, registerRequestDto.Password)
            };
            var identityResult = await _userManager.CreateAsync(identityUser);
            if(identityResult.Succeeded)
            {
                if(registerRequestDto.Roles != null&& registerRequestDto.Roles.Any())
                {
                    var identityRoleResult = await _userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);
                    if(identityRoleResult.Succeeded)
                    {
                        return Ok("User Registered");
                    } else
                    {
                        return BadRequest();
                    }
                }
                return Ok("User Registered");
            } else
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("CreateRole")]

        public async Task <IActionResult> CreateRole([FromBody] RoleCreateRequestDto roleCreateRequestDto)
        {
            if(roleCreateRequestDto == null)
            {
                return NotFound();
            } else
            {
                await _roleManager.CreateAsync(new Role { Name = roleCreateRequestDto.Name , Id = Guid.NewGuid()});
                return Ok();
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDto.Username);
            if(user != null)
            {
                var checkPasswordResult = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
                if(checkPasswordResult)
                {
                    return Ok();
                }
            }
            return BadRequest("Username or Password is incorrect");
        }
    }
}
