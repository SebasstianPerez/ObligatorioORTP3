using DTOs.DTOs.Usuario;
using LogicaNegocio.VO;
using System.ComponentModel.DataAnnotations;

namespace DTOs.DTOs.Envio
{
    public class DTOEnvio
    {
        [Required]
        public string Tipo { get; set; }

        [Required]
        public string NumeroTracking { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        public string ClienteEmail { get; set; }

        [Required]
        public int EmpleadoId { get; set; }

        [Required]
        [Range(0.1, 10000, ErrorMessage = "El peso debe estar entre 0.1 y 10000 kg")]
        public double Peso { get; set; }

        public string Estado { get; set; }

        public int? AgenciaId { get; set; }
        public string? DireccionPostal { get; set; }

        public DTOEnvio()
        {
            
        }

        public DTOEnvio(string numeroTracking, string clienteEmail, int empleadoId, double peso, string estado, int? agenciaId, string? direccionPostal)
        {
            NumeroTracking = numeroTracking;
            ClienteEmail = clienteEmail;
            EmpleadoId = empleadoId;
            Peso = peso;
            Estado = estado;
            AgenciaId = agenciaId;
            DireccionPostal = direccionPostal;
        }
    }
}