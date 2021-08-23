using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi.DTOs;
using WebApi.Extensions;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public UsuarioController(SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager,
                              IOptions<AppSettings> appSettings,
                              IEnderecoRepository enderecoRepository,
                              IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("nova-conta")]
        public async Task<ActionResult> Cadastrar(RegisterUserDTO registerUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Ok(GerarJwt());
            }
            
            return BadRequest(registerUser);            
        }

        [AllowAnonymous]
        [HttpPost("entrar")]
        public async Task<ActionResult> Login(LoginUserDTO loginUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {                
                return Ok(GerarJwt());
            }
            if (result.IsLockedOut)
            {                
                return BadRequest("Usuário temporariamente bloqueado por tentativas inválidas");
            }
            
            return BadRequest("Usuário ou Senha incorretos");            
        }

        [HttpPost("cadastrar-endereco-entrega")]
        public async Task<ActionResult> CadastrarEnderecoEntrega(EnderecoEntregaDTO enderecoEntregaDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            // cadastrar endereco de entrega
            await _enderecoRepository.Adicionar(_mapper.Map<Endereco>(enderecoEntregaDTO));
            return Ok();
        }               

        [HttpPost("consultar-saldo-de-pontos-e-extrato")]
        public async Task<ActionResult> ConsultarSaldoPontosExtrato(LoginUserDTO loginUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            // consultar saldo de pontos e extrato
            
            return Ok();
        }

        private string GerarJwt()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,                
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            return encodedToken;
        }
    }
}
