using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filtros
{
    public class Logged : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var userId = context.HttpContext.Session.GetString("UsuarioID");
            var rol = context.HttpContext.Session.GetString("UsuarioRol");

            if (string.IsNullOrEmpty(userId))
                context.Result = new RedirectToActionResult("Login", "Usuario", null);

            if(!rol.Equals("Empleado") && !rol.Equals("Admin"))
            {                
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
                
            base.OnActionExecuting(context);
        }
    }
}
