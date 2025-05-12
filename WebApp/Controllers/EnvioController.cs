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

        public EnvioController(ICUAltaEnvio cuAltaEnvio, ICUGetEnvios cuGetEnvios, ICUGetEnvio cuGetEnvio)
        {
            _cuAltaEnvio = cuAltaEnvio;
            _cuGetEnvios = cuGetEnvios;
            _cuGetEnvio = cuGetEnvio;
        }

        public IActionResult Index()
        {
            var envios = _cuGetEnvios.Ejecutar();
            return View(envios);
        }

        public IActionResult Create()
        {
            DTOAltaEnvioRequest model = new DTOAltaEnvioRequest();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(DTOAltaEnvioRequest dto)
        {
            try
            {
                _cuAltaEnvio.Ejecutar(dto);

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
