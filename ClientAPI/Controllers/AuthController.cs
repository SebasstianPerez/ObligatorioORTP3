using DTOs.DTOs.Usuario;
using LogicaAplicacion.ICasosUso.ICUUsuario;
using Microsoft.AspNetCore.Mvc;

namespace ClientAPI.Controllers
{
    public class AuthController : Controller
    {
        private readonly ICULogin _cuLogin;

        public AuthController(ICULogin cuLogin)
        {
            _cuLogin = cuLogin;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult Login()
        {
            try
            {
                //DTOLoginResponse dtoUsuario = _cuLogin.ValidarDatosLogin(dto);
                //TODO Login API
                //HttpContext.Session.SetInt32("UsuarioID", dtoUsuario.ID);

                TempData["Message"] = "Logueado correctamente";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al iniciar sesión: " + ex.Message;
                return View();
            }
        }

        
    }
}
