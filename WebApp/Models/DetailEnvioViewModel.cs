using DTOs.DTOs.Envio;

namespace WebApp.Models
{
    public class DetailEnvioViewModel
    {
        public DTOEnvio envio { get; set; }

        public List<DTOSeguimiento> seguimientos { get; set; }

        public DetailEnvioViewModel(DTOEnvio envio, List<DTOSeguimiento> seguimientos)
        {
            this.envio = envio;
            this.seguimientos = seguimientos;
        }

        public DetailEnvioViewModel()
        {
            
        }
    }
}
