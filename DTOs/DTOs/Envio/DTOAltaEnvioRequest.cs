using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.Envio
{
    public class DTOAltaEnvioRequest
    {
        [Required]
        public string TipoEnvio { get; set; }

        [Required(ErrorMessage = "El email del cliente es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del email es incorrecto")]
        public string EmailCliente { get; set; }

        [Required]
        public int LogueadoId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El nombre del destinatario no puede exceder los 50 caracteres")]
        public string? AgenciaDestino { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La dirección postal no puede exceder los 100 caracteres")]
        public string? DireccionPostal { get; set; }

        [Required]
        [Range(0.01, 10000.00, ErrorMessage = "El peso debe estar entre 0.01 y 10000.00")]
        public double Peso { get; set; }

        public string MyProperty { get; set; }
    }
}
