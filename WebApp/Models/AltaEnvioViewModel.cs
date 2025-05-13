using DTOs.DTOs.Envio;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models
{
    public class AltaEnvioViewModel
    {
        public DTOEnvio dtoEnvio { get; set; }

        public List<SelectListItem> TipoEnvio = new List<SelectListItem>();

        public List<SelectListItem> Agencias = new List<SelectListItem>();

        public AltaEnvioViewModel(DTOEnvio dtoEnvio, List<SelectListItem> tipoEnvio, List<SelectListItem> agencias)
        {
            this.dtoEnvio = dtoEnvio;
            TipoEnvio = tipoEnvio;
            Agencias = agencias;
        }

        public AltaEnvioViewModel()
        {
            
        }
    }
}
