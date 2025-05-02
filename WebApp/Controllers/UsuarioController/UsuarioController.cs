using DTOs.DTOs.Usuario;
using LogicaAplicacion.ICasosUso.ICUUsuario;
using LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filtros;

namespace WebApp.Controllers.UsuarioController
{
    public class UsuarioController : Controller
    {
        private readonly ICULogin _cuLogin;
        //private readonly ICULogout _cuLogout;
        private readonly ICUAltaUsuario _cUAltaUsuario;
        //private readonly ICURecuperarContrasena _cuRecuperarContrasena;
        private readonly ICUBajaUsuario _cUBajaUsuario;
        private readonly ICUEditarUsuario _cuEditarUsuario;
        private readonly ICUGetUsuarios _cuGetUsuarios;

        public UsuarioController(ICULogin cuLogin, ICUAltaUsuario cUAltaUsuario, ICUGetUsuarios cuGetUsuarios)
        {
            _cuLogin = cuLogin;
            _cUAltaUsuario = cUAltaUsuario;
            _cuGetUsuarios = cuGetUsuarios;
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

                HttpContext.Session.SetInt32("UsuarioID", (int)(dtoUsuario.ID));
                HttpContext.Session.SetString("UsuarioRol", dtoUsuario.Rol);

                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
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

                ViewBag.msg = "Usuario creado con éxito";
            } catch(Exception ex) {
                ViewBag.ErrorMsg = "Error al crear el usuario: " + ex.Message;
            }

            return View();
        }

        public IActionResult Edit()
        {

        }

        [HttpPost]
        public IActionResult Edit()
        {
            //TODO Editar usuario
        }
    }
}
