using DTOs.DTOs.Envio;
using DTOs.DTOs.Usuario;
using LogicaAplicacion.ICasosUso.ICUAgencia;
using LogicaAplicacion.ICasosUso.ICUEnvio;
using LogicaAplicacion.ICasosUso.ICUUsuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Filtros;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EnvioController : Controller
    {
        private readonly ICUAltaEnvio _cuAltaEnvio;
        private readonly ICUGetEnvios _cuGetEnvios;
        private readonly ICUGetEnvio _cuGetEnvio;
        private readonly ICUGetAgencias _cuGetAgencias;

        public EnvioController(ICUAltaEnvio cuAltaEnvio, ICUGetEnvios cuGetEnvios, ICUGetEnvio cuGetEnvio, ICUGetAgencias cuGetAgencias)
        {
            _cuAltaEnvio = cuAltaEnvio;
            _cuGetEnvios = cuGetEnvios;
            _cuGetEnvio = cuGetEnvio;
            _cuGetAgencias = cuGetAgencias;
        }

        public IActionResult Index()
        {
            var envios = _cuGetEnvios.Ejecutar();
            return View(envios);
        }

        [Logged]
        public IActionResult Create()
        {
            AltaEnvioViewModel vm = new AltaEnvioViewModel();

            foreach(var agencia in _cuGetAgencias.Ejecutar())
            {
                SelectListItem sitem = new SelectListItem();
                sitem.Text = agencia.Nombre;
                sitem.Value = agencia.Id.ToString();
                vm.Agencias.Add(sitem); 
            }

            vm.TipoEnvio = new List<SelectListItem>()
            {
                new SelectListItem("Comun", value: "Comun"),
                new SelectListItem("Urgente", value: "Urgente")
            };
            
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(AltaEnvioViewModel vm)
        {
            try
            {
                vm.dtoEnvio.EmpleadoId = (int)HttpContext.Session.GetInt32("UsuarioID");

                _cuAltaEnvio.Ejecutar(vm.dtoEnvio);

                ViewData["Message"] = "Alta correcta";

                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return RedirectToAction("Create");
            }
        }
    }
}
