using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.Usuario
{
    public class DTOLoginRequest
    {
        
        [Required]
        [StringLength(100, ErrorMessage = "El correo electrónico no puede exceder los 100 caracteres.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }

        public DTOLoginRequest()
        {
            
        }

        public DTOLoginRequest(string email, string contrasena)
        {
            Email = email;
            Contrasena = contrasena;
        }

    }
}
