using DTOs.DTOs.Usuario;
using LogicaNegocio.Entidades;
using LogicaNegocio.VO;
using System.ComponentModel.DataAnnotations;

namespace DTOs.DTOs.Envio
{
    public class DTOEnvio
    {
        public int Id { get; set; }
        [Required]
        public string Tipo { get; set; }

        [Required]
        public string NumeroTracking { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        public string? ClienteEmail { get; set; }

        [Required]
        public int EmpleadoId { get; set; }

        [Required]
        [Range(0.1, 10000, ErrorMessage = "El peso debe estar entre 0.1 y 10000 kg")]
        public double Peso { get; set; }

        public string Estado { get; set; }

        public List<DTOSeguimiento>? Seguimientos { get; set; } = new List<DTOSeguimiento>();

        public int? AgenciaId { get; set; }
        public string? AgenciaNombre { get; set; }
        public string? DireccionPostal { get; set; }

        public DTOEnvio()
        {
            
        }

        public DTOEnvio(int id, string tipo, string numeroTracking, string? clienteEmail, int empleadoId, double peso, string estado, List<DTOSeguimiento>? seguimientos, int? agenciaId, string? direccionPostal)
        {
            Id = id;
            Tipo = tipo;
            NumeroTracking = numeroTracking;
            ClienteEmail = clienteEmail;
            EmpleadoId = empleadoId;
            Peso = peso;
            Estado = estado;
            Seguimientos = seguimientos;
            AgenciaId = agenciaId;
            DireccionPostal = direccionPostal;
        }
    }
}