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
        private readonly ICUGetEnviosCliente _cuGetEnviosCliente;
        private readonly ICUGetEnviosClientePorFecha _cuGetEnviosClientePorFecha;
        private readonly ICUGetEnviosPorComentario _cuGetEnviosPorComentario;
        private readonly IConfiguration _config;

        public EnvioController(ICUGetEnvioTracking cuGetEnvioTracking,
            ICUGetEnviosCliente cuGetEnviosCliente,
            IConfiguration config,
            ICUGetEnviosPorComentario cuGetEnviosPorComentario,
            ICUGetEnviosClientePorFecha cuGetEnviosClientePorFecha)
        {
            _cuGetEnvioTracking = cuGetEnvioTracking;
            _cuGetEnviosCliente = cuGetEnviosCliente;
            _cuGetEnviosClientePorFecha = cuGetEnviosClientePorFecha;
            _cuGetEnviosPorComentario = cuGetEnviosPorComentario;
            _config = config;
        }

        [HttpGet]
        [Authorize(Roles = "Cliente")]
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

        [HttpGet("GetEnvios")]
        [Authorize(Roles = "Cliente")]
        public IActionResult GetEnvios()
        {
            try
            {
                String email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

                List<DTOEnvio> envios = _cuGetEnviosCliente.Ejecutar(email);

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

        [HttpGet("GetPorFecha")]
        [Authorize(Roles = "Cliente")]
        public IActionResult GetEnviosPorFecha(DateTime fechaInicio, [FromQuery] DateTime fechaFin)
        {
            try
            {
                String email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

                List<DTOEnvio> envios = _cuGetEnviosClientePorFecha.Ejecutar(email, fechaInicio, fechaFin);

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
    }
}
