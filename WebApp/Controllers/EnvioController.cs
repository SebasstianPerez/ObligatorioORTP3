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
        private readonly ICUGetEnviosEnProceso _cuGetEnviosEnProceso;
        private readonly ICUFinalizarEnvio _cuFinalizarEnvio;

        public EnvioController(ICUAltaEnvio cuAltaEnvio, ICUGetEnvios cuGetEnvios, ICUGetEnvio cuGetEnvio, ICUGetAgencias cuGetAgencias, ICUGetEnviosEnProceso cuGetEnviosEnProceso, ICUFinalizarEnvio cuFinalizarEnvio)
        {
            _cuAltaEnvio = cuAltaEnvio;
            _cuGetEnvios = cuGetEnvios;
            _cuGetEnvio = cuGetEnvio;
            _cuGetAgencias = cuGetAgencias;
            _cuGetEnviosEnProceso = cuGetEnviosEnProceso;
            _cuFinalizarEnvio = cuFinalizarEnvio;
        }

        [Logged]
        public IActionResult Index()
        {
            var envios = _cuGetEnviosEnProceso.Ejecutar();
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
        [Logged]
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

        [Logged]
        [HttpGet]
        public IActionResult FinalizarEnvio(int id)
        {
            try
            {
                DTOEnvio envio = _cuGetEnvio.Ejecutar(id);
                if(envio == null)
                    throw new Exception("El envio no existe");
                
                return View(envio);
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [Logged]
        public IActionResult FinalizarConfirmacion(int id)
        {
            try
            {
                var envio = _cuGetEnvio.Ejecutar(id);
                if (envio == null)
                    throw new Exception("El envio no existe");

                _cuFinalizarEnvio.Ejecutar(id, (int)HttpContext.Session.GetInt32("UsuarioID"));
                ViewData["Message"] = "Envio finalizado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["Error"] = "Error al finalizar el envio: " + ex.Message;
                return RedirectToAction("Index");
            }
        }
        /*
         public IActionResult Update(int idEnvio)
        {
            DTOEnvio envio = _cuGetEnvio.Ejecutar(idEnvio);

            return View(envio);
        }

        [HttpPost]
        [Logged]
        public IActionResult Update()
        {
            try
            {

            }
            catch ()
            {

            }
        }
         */
    }
}
