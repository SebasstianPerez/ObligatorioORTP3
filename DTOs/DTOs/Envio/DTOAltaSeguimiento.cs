using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.Envio
{
    public class DTOAltaSeguimiento
    {
        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "El comentario no puede exceder los 500 caracteres.")]
        [MinLength(10, ErrorMessage = "El comentario debe tener al menos 10 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s.,;:!?]+$", ErrorMessage = "El comentario solo puede contener letras, números y algunos signos de puntuación.")]
        public string Comentario { get; set; }

        [Required]
        public int IdEnvio { get; set; }

        [Required]
        public int IdEmpleado { get; set; }
    }
}
