using DTOs.DTOs.Envio;
using LogicaAplicacion.ICasosUso.ICUEnvio;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Cliente")]
        public IActionResult GetEnvio([FromQuery] string nroTracking)
        {
            try
            {
                DTOEnvio dto = _cuGetEnvioTracking.Ejecutar(nroTracking);

                if (dto == null)
                    return StatusCode(404, "Envio no encontrado");
                

                return Ok(dto);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
