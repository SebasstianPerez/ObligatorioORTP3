using DTOs.DTOs.Usuario;
using LogicaAplicacion.ICasosUso.ICUUsuario;
using Microsoft.AspNetCore.Mvc;

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

        public UsuarioController(ICULogin cuLogin)
        {
            _cuLogin = cuLogin;
        }

        public IActionResult Index()
        {
            return View("Login");
        }

        public IActionResult Login()
        {
            var model = new DTOLogin();

            return View(model);
        }

        [HttpPost]
        public IActionResult Login(DTOLogin dto)
        {
            try
            {
                DTOUsuario dtoUsuario = _cuLogin.ValidarDatosLogin(dto);

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


        //TODO CRUD Usuario
    }
}
