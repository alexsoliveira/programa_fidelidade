using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [Route("api/conta")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(RegisterUserDTO registerUser)
        {
            //if (!ModelState.IsValid) return CustomResponse(ModelState);

            //var user = new IdentityUser
            //{
            //    UserName = registerUser.Email,
            //    Email = registerUser.Email,
            //    EmailConfirmed = true
            //};

            //var result = await _userManager.CreateAsync(user, registerUser.Password);
            //if (result.Succeeded)
            //{
            //    await _signInManager.SignInAsync(user, false);
            //    return CustomResponse(await GerarJwt(user.Email));
            //}
            //foreach (var error in result.Errors)
            //{
            //    NotificarErro(error.Description);
            //}

            //return CustomResponse(registerUser);
            return Ok();
        }
    }
}
