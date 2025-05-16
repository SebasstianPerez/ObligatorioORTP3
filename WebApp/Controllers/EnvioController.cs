using DTOs.DTOs.Envio;
using DTOs.DTOs.Usuario;
using LogicaAplicacion.ICasosUso.ICUAgencia;
using LogicaAplicacion.ICasosUso.ICUEnvio;
using LogicaAplicacion.ICasosUso.ICUSeguimiento;
using LogicaAplicacion.ICasosUso.ICUUsuario;
using LogicaNegocio.Entidades;
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
        private readonly ICUAgregarSeguimiento _cuAgregarSeguimiento;

        public EnvioController(ICUAltaEnvio cuAltaEnvio, ICUGetEnvios cuGetEnvios, ICUGetEnvio cuGetEnvio, ICUGetAgencias cuGetAgencias, ICUGetEnviosEnProceso cuGetEnviosEnProceso, ICUFinalizarEnvio cuFinalizarEnvio, ICUAgregarSeguimiento cuAgregarSeguimiento)
        {
            _cuAltaEnvio = cuAltaEnvio;
            _cuGetEnvios = cuGetEnvios;
            _cuGetEnvio = cuGetEnvio;
            _cuGetAgencias = cuGetAgencias;
            _cuGetEnviosEnProceso = cuGetEnviosEnProceso;
            _cuFinalizarEnvio = cuFinalizarEnvio;
            _cuAgregarSeguimiento = cuAgregarSeguimiento;
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
            try
            {
                AltaEnvioViewModel vm = ConstruirAltaEnvioViewModel();

                return View(vm);
            }
            catch(Exception ex)
            {
                AltaEnvioViewModel vm = ConstruirAltaEnvioViewModel();

                ViewData["Error"] = ex.Message;
                return View(vm);
            }
        }

        [HttpPost]
        [Logged]
        public IActionResult Create(AltaEnvioViewModel vm)
        {
            try
            {
                vm.dtoEnvio.EmpleadoId = (int)HttpContext.Session.GetInt32("UsuarioID");

                _cuAltaEnvio.Ejecutar(vm.dtoEnvio);

                TempData["Message"] = "Alta correcta";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                AltaEnvioViewModel vm1 = ConstruirAltaEnvioViewModel();

                ViewData["Error"] = ex.Message;
                return View(vm1);
            }
        }

        private AltaEnvioViewModel ConstruirAltaEnvioViewModel()
        {
            AltaEnvioViewModel vm = new AltaEnvioViewModel();

            foreach (var agencia in _cuGetAgencias.Ejecutar())
            {
                vm.Agencias.Add(new SelectListItem
                {
                    Text = agencia.Nombre,
                    Value = agencia.Id.ToString()
                });
            }

            vm.TipoEnvio = new List<SelectListItem>
            {
                new SelectListItem("Comun", value: "Comun"),
                new SelectListItem("Urgente", value: "Urgente")
            };

            return vm;
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

                DTOFinalizarEnvio dto = new DTOFinalizarEnvio();
                dto.EnvioId = id;
                dto.LogueadoId = (int)HttpContext.Session.GetInt32("UsuarioID");

                _cuFinalizarEnvio.Ejecutar(dto);
                ViewData["Message"] = "Envio finalizado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["Error"] = "Error al finalizar el envio: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        
         [Logged]
         public IActionResult Details(int id)
        {
            try
            {
                DetailEnvioViewModel vm = CrearDetailVM(id);

                return View(vm);
            } 
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return View();
            }
            
        }

        [HttpPost]
        [Logged]
        public IActionResult Details(DTOSeguimiento dto)
        {
            try
            {
                dto.EmpleadoId = (int)HttpContext.Session.GetInt32("UsuarioID");

                if (dto.Comentario == null || dto.Comentario == "")
                    throw new Exception("El comentario no puede estar vacio");

                if (dto.EmpleadoId == 0)
                    throw new Exception("El id del empleado no puede ser 0");

                _cuAgregarSeguimiento.Ejecutar(dto);

                ViewData["Message"] = "Seguimiento agregado correctamente";
                return RedirectToAction("Details", dto.EnvioId);
            }
            catch (Exception ex)
            {
                DetailEnvioViewModel vm =  CrearDetailVM(dto.EnvioId);
                
                ViewData["Error"] = ex.Message;
                return View(vm);
            }
        }

        public DetailEnvioViewModel CrearDetailVM(int idEnvio)
        {
            try
            {
                DTOEnvio envio = _cuGetEnvio.Ejecutar(idEnvio);

                DetailEnvioViewModel vm = new DetailEnvioViewModel();
                vm.envio = envio;
                vm.seguimientos = envio.Seguimientos;

                return vm;
            }
            catch(Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return null;
            }
        }


    }
}
