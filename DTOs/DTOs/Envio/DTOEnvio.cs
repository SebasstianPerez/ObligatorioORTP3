using DTOs.DTOs.Usuario;
using LogicaNegocio.VO;
using System.ComponentModel.DataAnnotations;

namespace DTOs.DTOs.Envio
{
    public class DTOEnvio
    {
        public String Tipo { get; set; }
        [Required]
        public string NumeroTracking { get; set; }

        [Required]
        public string ClienteEmail { get; set; }

        [Required]
        public int EmpleadoId { get; set; }

        [Required]
        public double Peso { get; set; }

        public string Estado { get; set; }

        public string? AgenciaNombre { get; set; }
        public string? DireccionPostal { get; set; }

        public DTOEnvio()
        {
            
        }

        public DTOEnvio(string numeroTracking, string clienteEmail, int empleadoId, double peso, string estado, string? agenciaNombre, string? direccionPostal)
        {
            NumeroTracking = numeroTracking;
            ClienteEmail = clienteEmail;
            EmpleadoId = empleadoId;
            Peso = peso;
            Estado = estado;
            AgenciaNombre = agenciaNombre;
            DireccionPostal = direccionPostal;
        }
    }
}