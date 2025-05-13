using DTOs.DTOs.Envio;
using DTOs.DTOs.Usuario;
using LogicaAplicacion.ICasosUso.ICUAgencia;
using LogicaAplicacion.ICasosUso.ICUEnvio;
using LogicaAplicacion.ICasosUso.ICUUsuario;
using LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult Create()
        {
            DTOEnvio dto = new DTOEnvio();
            AltaEnvioViewModel vm = new AltaEnvioViewModel();

            foreach(var agencia in _cuGetAgencias.Ejecutar())
            {
                SelectListItem sitem = new SelectListItem();
                sitem.Text = agencia.Nombre;
                sitem.Value = agencia.Nombre;
                vm.Agencias.Add(sitem); 
            }
            
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(AltaEnvioViewModel vm)
        {
            try
            {
                //TODO terminar controller envio create
                vm.dtoEnvio.EmpleadoId = (int)HttpContext.Session.GetInt32("UsuarioID");

                //_cuAltaEnvio.Ejecutar();

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
