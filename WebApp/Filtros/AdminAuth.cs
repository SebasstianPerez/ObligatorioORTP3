using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filtros
{
    public class AdminAuth : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var userRole = context.HttpContext.Session.GetString("UsuarioRol");

            if (string.IsNullOrEmpty(userRole)) 
                context.Result = new RedirectToActionResult("Login", "Usuario", null);
            else if (userRole != "Admin")
                context.Result = new RedirectToActionResult("Index", "Home", null);

            base.OnActionExecuting(context);
        }
    }
}
