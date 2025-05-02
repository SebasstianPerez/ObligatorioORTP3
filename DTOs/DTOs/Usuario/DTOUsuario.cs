using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.Usuario
{
    public class DTOUsuario
    {
        [Required(ErrorMessage = "El id no puede ser vacio.")]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El apellido no puede exceder los 50 caracteres.")]
        public string Apellido { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "El email no es válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El rol no puede ser vacio.")]
        public string Rol { get; set; }

        public DTOUsuario()
        {
            
        }

        public DTOUsuario(string nombre, string apellido, string email, string rol)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Rol = rol;
        }
    }
}
