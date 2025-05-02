using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.Usuario
{
    public class DTOListUsuarios
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }

        public DTOListUsuarios()
        {
            
        }

        public DTOListUsuarios(string nombre, string apellido, string email, string rol)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Rol = rol;
        }
    }
}
