using LogicaNegocio.VO;
using System.ComponentModel.DataAnnotations;

namespace DTOs.DTOs.Envio
{
    public class DTOGetAllEnvios
    {
        [Required(ErrorMessage = "El tipo es obligatorio")]
        public string Tipo { get; set; }
        [Required]
        public string EmailCliente { get; set; }
        [Required]
        public string Agencia { get; set; }
        [Required]
        public string DireccionPostal { get; set; }
        [Required]
        public double Peso { get; set; }

    }
}