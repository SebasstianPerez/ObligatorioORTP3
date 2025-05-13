using DTOs.DTOs.Envio;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models
{
    public class AltaEnvioViewModel
    {
        public DTOEnvio dtoEnvio { get; set; }

        public List<SelectListItem> TipoEnvio = new List<SelectListItem>()
        {
            new SelectListItem("Urgente", "urgente"),
            new SelectListItem("Comun", "comun")

        };

        public List<SelectListItem> Agencias = new List<SelectListItem>()
        {
             new SelectListItem("DHL", "DHL"),
             new SelectListItem("FedEx", "FedEx")
        };
    }
}
