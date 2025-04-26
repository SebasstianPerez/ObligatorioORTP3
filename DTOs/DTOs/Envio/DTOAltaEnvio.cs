using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.Envio
{
    public class DTOAltaEnvio
    {
        [System.ComponentModel.DataAnnotations.Schema.Column("id_envio")]
        [Key]
        public string NumeroTracking { get; set; }

        [Required]
        public string Empleado { get; set; }

        [Required]
        public string Cliente { get; set; }

        [Required]
        [Range(0.01, 10000.00, ErrorMessage = "El peso debe estar entre 0.01 y 10000.00")]
        public double Peso { get; set; }
    }
}
