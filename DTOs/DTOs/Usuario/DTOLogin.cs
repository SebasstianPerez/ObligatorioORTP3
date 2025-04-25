using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.Usuario
{
    public class DTOLogin
    {
        
        [Required]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        [StringLength(100, ErrorMessage = "El correo electrónico no puede exceder los 100 caracteres.")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.", MinimumLength = 6)]
        [Required]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }


    }
}
