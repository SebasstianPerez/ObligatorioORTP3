using DTOs.DTOs.Usuario;
using LogicaAplicacion.ICasosUso.ICUUsuario;
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

                TempData["Message"] = "Logueado correctamente";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al iniciar sesión: " + ex.Message;
                return View();
            }
        }

        [Logged]
        [HttpPost]
        public IActionResult Logout()
        {
            try
            {
                HttpContext.Session.Clear();

                TempData["Message"] = "Sesión cerrada correctamente";
                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                TempData["Error"] = "No se pudo cerrar sesion";
                return RedirectToAction("Login");
            }
        }

        [AdminAuth]
        public IActionResult Create()
        {
            var model = new DTOCreateRequest();

            return View(model);
        }

        [HttpPost]
        [Logged]
        public IActionResult Create(DTOCreateRequest dto)
        {
            try
            {
                int logId = (int)HttpContext.Session.GetInt32("UsuarioID");

                dto.LogueadoId = logId;

                _cUAltaUsuario.Ejecutar(dto);

                TempData["Message"] = "Usuario creado con éxito";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["Error"] = "Error al crear el usuario: " + ex.Message;
                return View();
            }
        }

        [AdminAuth]
        public IActionResult Edit(int id)
        {
            var usuario = _cuGetDatosUsuario.Ejecutar(id);
            return View(usuario);
        }

        [HttpPost]
        [AdminAuth]
        public IActionResult Edit(DTOEditarUsuarioRequest dto)
        {
            try
            {
                int logeadoId = (int)HttpContext.Session.GetInt32("UsuarioID");

                dto.loguadoId = logeadoId;
                _cuEditarUsuario.Ejecutar(dto);

                TempData["Message"] = "Usuario editado con éxito";
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
            DTOUsuario aBorrar = _cuGetDatosUsuario.Ejecutar(id);
            return View(aBorrar);
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

                TempData["Message"] = "Usuario eliminado con éxito";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al eliminar al usuario: " + ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
