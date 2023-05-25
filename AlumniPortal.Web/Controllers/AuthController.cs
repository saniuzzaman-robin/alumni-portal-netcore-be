using AlumniPortal.Domain.DTOs;
using AlumniPortal.Domain.Models;
using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AlumniPortal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        public AuthController(UserManager<User> userManager, RoleManager<Role> roleManager) { 
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            if (registerRequestDto == null)
            {
                return NotFound();
            }
            var identityUser = new User
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
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
    }
}
