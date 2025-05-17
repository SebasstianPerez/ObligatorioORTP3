using DTOs.DTOs.Envio;
using LogicaAplicacion.ICasosUso.ICUEnvio;
using Microsoft.AspNetCore.Mvc;

namespace ClientAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnvioController : ControllerBase
    {
        private readonly ICUGetEnvioTracking _cuGetEnvioTracking;

        public EnvioController(ICUGetEnvioTracking cuGetEnvioTracking)
        {
            _cuGetEnvioTracking = cuGetEnvioTracking;
        }

        [HttpGet]
        public IActionResult GetEnvio([FromQuery] string nroTracking)
        {
            try
            {
                DTOEnvio dto = _cuGetEnvioTracking.Ejecutar(nroTracking);

                if (dto == null)
                {
                    return NotFound("El envio no existe");
                }

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
