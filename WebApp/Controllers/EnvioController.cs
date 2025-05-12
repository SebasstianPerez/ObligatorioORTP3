using DTOs.DTOs.Envio;
using LogicaAplicacion.ICasosUso.ICUEnvio;
using LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class EnvioController : Controller
    {
        private readonly ICUAltaEnvio _cuAltaEnvio;
        private readonly ICUGetEnvios _cuGetEnvios;
        private readonly ICUGetEnvio _cuGetEnvio;
        private readonly ICUEditarEnvio _cuEditarEnvio;

        public EnvioController(ICUAltaEnvio cuAltaEnvio, ICUGetEnvios cuGetEnvios, ICUGetEnvio cuGetEnvio,
            ICUEditarEnvio cuEditarEnvio)
        {
            _cuAltaEnvio = cuAltaEnvio;
            _cuGetEnvios = cuGetEnvios;
            _cuGetEnvio = cuGetEnvio;
            _cuEditarEnvio = cuEditarEnvio;
        }

        public IActionResult Index()
        {
            var envios = _cuGetEnvios.Ejecutar();
            return View(envios);
        }

        [HttpGet]
        public IActionResult AltaEnvio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AltaEnvio()
        {
            try
            {
                DTOAltaEnvioRequest envio = new DTOAltaEnvioRequest();
                envio.TipoEnvio = Request.Form["TipoEnvio"];
                envio.EmailCliente = Request.Form["EmailCliente"];
                envio.Peso = Convert.ToDouble(Request.Form["Peso"]);

                if(envio.TipoEnvio == "Comun")
                {
                    envio.AgenciaDestino = Request.Form["AgenciaUrgente"];
                }
                else if(envio.TipoEnvio == "Urgente")
                {
                    envio.DireccionPostal = Request.Form["DireccionPostal"];
                }

                _cuAltaEnvio.Ejecutar(envio);

                ViewBag.Message = "Alta correcta";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }
    }
}
