using DTOs.DTOs.Usuario;
using LogicaAplicacion.ICasosUso.ICUUsuario;
using LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filtros;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ICULogin _cuLogin;
        private readonly ICUAltaUsuario _cUAltaUsuario;
        //private readonly ICURecuperarContrasena _cuRecuperarContrasena;
        private readonly ICUBajaUsuario _cUBajaUsuario;
        private readonly ICUEditarUsuario _cuEditarUsuario;
        private readonly ICUGetUsuarios _cuGetUsuarios;
        private readonly ICUGetDatosUsuario _cuGetDatosUsuario;
        private readonly ICUBajaUsuario _cuBajaUsuario;

        public UsuarioController(ICULogin cuLogin, ICUAltaUsuario cUAltaUsuario,
            ICUGetUsuarios cuGetUsuarios, ICUEditarUsuario cuEditarUsuario, ICUGetDatosUsuario cuGetDatosUsuario,
            ICUBajaUsuario cuBajaUsuario)
        {
            _cuLogin = cuLogin;
            _cUAltaUsuario = cUAltaUsuario;
            _cuGetUsuarios = cuGetUsuarios;
            _cuEditarUsuario = cuEditarUsuario;
            _cuGetDatosUsuario = cuGetDatosUsuario;
            _cuBajaUsuario = cuBajaUsuario;
        }

        [AdminAuth]
        public IActionResult Index()
        {
            var usuarios = _cuGetUsuarios.Ejecutar();
            return View(usuarios);
        }

        public IActionResult Login()
        {
            DTOLoginRequest model = new();

            return View(model);
        }

        [HttpPost]
        public IActionResult Login(DTOLoginRequest dto)
        {
            try
            {
                DTOLoginResponse dtoUsuario = _cuLogin.ValidarDatosLogin(dto);

                HttpContext.Session.SetInt32("UsuarioID", dtoUsuario.ID);
                HttpContext.Session.SetString("UsuarioRol", dtoUsuario.Rol);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al iniciar sesión: " + ex.Message;
                return View();
            }
        }

        [Logged]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UsuarioID");
            HttpContext.Session.Remove("UsuarioRol");

            return RedirectToAction("Index", "Home");
        }

        [AdminAuth]
        public IActionResult Create()
        {
            var model = new DTOCreateRequest();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(DTOCreateRequest dto)
        {
            try
            {
                int? logId = HttpContext.Session.GetInt32("UsuarioID");
                if (logId == null)
                {
                    ViewBag.ErrorMessage = "No se ha iniciado sesión";
                    return RedirectToAction("Index", "Home");
                }

                dto.LogueadoId = (int)logId;

                _cUAltaUsuario.Ejecutar(dto);

                ViewData["Message"] = "Usuario creado con éxito";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = "Error al crear el usuario: " + ex.Message;
            }

            return View();
        }

        [AdminAuth]
        public IActionResult Edit(int id)
        {
            var usuario = _cuGetDatosUsuario.Ejecutar(id);
            return View(usuario);
        }

        [HttpPut]
        [AdminAuth]
        public IActionResult Edit(DTOEditarUsuarioRequest dto)
        {
            try
            {
                int? logeadoId = HttpContext.Session.GetInt32("UsuarioID");
                if (logeadoId == null)
                {
                    ViewData["ErrorMessage"] = "No se ha iniciado sesión";
                    return RedirectToAction("Index", "Home");
                }

                dto.loguadoId = (int)logeadoId;
                _cuEditarUsuario.Ejecutar(dto);

                ViewData["Message"] = "Usuario editado con éxito";
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = "Error al editar el usuario: " + ex.Message;
                return View();
            }
        }

        [HttpGet]
        [AdminAuth]
        public IActionResult Delete(int id)
        {
            var item = _cuGetDatosUsuario.Ejecutar(id);
            return View(item); // Mostrás una vista de confirmación
        }


        [AdminAuth]
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                DTODelete dto = new DTODelete();

                dto.LogueadoId = (int)HttpContext.Session.GetInt32("UsuarioID");
                dto.UsuarioId = id;

                _cuBajaUsuario.Ejecutar(dto);

                ViewData["Message"] = "Usuario eliminado con éxito";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["Error"] = "Error al eliminar al usuario: " + ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
