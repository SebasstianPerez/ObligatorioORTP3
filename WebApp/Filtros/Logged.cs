using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filtros
{
    public class Logged : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var userId = context.HttpContext.Session.GetString("UsuarioID");

            if (string.IsNullOrEmpty(userId))
                context.Result = new RedirectToActionResult("Login", "Usuario", null);

            //TODO Manejar el error de usuario no autorizado

            base.OnActionExecuting(context);
        }
    }
}
