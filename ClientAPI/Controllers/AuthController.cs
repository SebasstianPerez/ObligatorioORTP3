using DTOs.DTOs.Usuario;
using LogicaAplicacion.ICasosUso.ICUUsuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClientAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly ICULogin _cuLogin;
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config, ICULogin cuLogin)
        {
            _cuLogin = cuLogin;
            _config = config;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] DTOLoginRequest dto)
        {
            try
            {
                DTOLoginResponse dtoUsuario = _cuLogin.ValidarDatosLogin(dto);

                var clave = _config["ClaveToken"];
                var claveCodificada = new
                SymmetricSecurityKey(Encoding.UTF8.GetBytes(clave));

                List<Claim> claims = [
                 new Claim(ClaimTypes.Email, dtoUsuario.Email),
                 new Claim(ClaimTypes.Role , dtoUsuario.Rol)
                ];

                var credenciales = new SigningCredentials(claveCodificada,
               SecurityAlgorithms.HmacSha512Signature);


                var token = new JwtSecurityToken(claims: claims, expires:
                                  DateTime.Now.AddDays(1), signingCredentials: credenciales);


                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { Token = jwt });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
