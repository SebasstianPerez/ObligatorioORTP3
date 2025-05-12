using LogicaNegocio.VO;
using System.ComponentModel.DataAnnotations;

namespace DTOs.DTOs.Envio
{
    public class DTOGetEnvios
    {
        [Required(ErrorMessage = "El tipo es obligatorio")]
        public string Tipo { get; set; }
        [Required]
        public string NumeroTracking { get; set; }
        [Required]
        public string EmailCliente { get; set; }
        [Required]
        public double Peso { get; set; }
        public string Estado { get; set; }

        public DTOGetEnvios()
        {
            
        }

        public DTOGetEnvios(string tipo, string numeroTracking, string emailCliente, double peso, string estado)
        {
            Tipo = tipo;
            NumeroTracking = numeroTracking;
            EmailCliente = emailCliente;
            Peso = peso;
            Estado = estado;
        }
    }
}