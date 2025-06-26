using DTOs.DTOs;
using DTOs.DTOs.Envio;
using LogicaAplicacion.ICasosUso.ICUEnvio;
using LogicaNegocio.CustomExceptions;
using LogicaNegocio.CustomExceptions.Envio;
using LogicaNegocio.CustomExceptions.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace ClientAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnvioController : ControllerBase
    {
        private readonly ICUGetEnvioTracking _cuGetEnvioTracking;
        private readonly ICUGetEnviosClienteFiltrado _cuGetEnviosCliente;
        private readonly IConfiguration _config;

        public EnvioController(ICUGetEnvioTracking cuGetEnvioTracking,
            ICUGetEnviosClienteFiltrado cuGetEnviosCliente,
            IConfiguration config)
        {
            _cuGetEnvioTracking = cuGetEnvioTracking;
            _cuGetEnviosCliente = cuGetEnviosCliente;
            _config = config;
        }

        [HttpGet("GetEnvio")]
        public IActionResult GetEnvio([FromQuery] string nroTracking)
        {
            try
            {
                DTOEnvio dto = _cuGetEnvioTracking.Ejecutar(nroTracking);

                return Ok(dto);
            }
            catch(EnvioNoExisteException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Cliente")]
        public IActionResult Index([FromQuery]DTOFiltro? dto)
        {
            try
            {
                dto ??= new DTOFiltro();

                String email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

                dto.Email = email;

                DTOPaginado<DTOEnvio> envios = _cuGetEnviosCliente.Ejecutar(dto);

                return Ok(envios);
            }
            catch (ClienteEnvioNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error de servidor");
            }
        }

        /*
         
        [HttpGet("GetPorFecha")]
        [Authorize(Roles = "Cliente")]
        public IActionResult GetEnviosPorFecha(DateTime fechaInicio, [FromQuery] DateTime fechaFin, Estado? estado)
        {
            try
            {
                String email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

                List<DTOEnvio> envios = _cuGetEnviosClientePorFecha.Ejecutar(email, estado, fechaInicio, fechaFin);

                return Ok(envios);
            }
            catch (EnvioNoExisteException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(FechaInvalidaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error de servidor");
            }
        }

        [HttpGet("GetPorComentario")]
        [Authorize(Roles = "Cliente")]
        public IActionResult GetEnviosPorComentario(string comentario)
        {
            try
            {
                string email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

                List<DTOEnvio> envios = _cuGetEnviosPorComentario.Ejecutar(email, comentario);

                return Ok(envios);
            }
            catch (UsuarioNoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (EnvioNoExisteException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error de servidor");
            }
        }
         */
    }
}
