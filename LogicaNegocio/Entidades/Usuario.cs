using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public NombreCompleto NombreCompleto { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }

        public Usuario() { }

        public Usuario(NombreCompleto nombreCompleto, string email, string contrasena, string rol)
        {
            NombreCompleto = nombreCompleto;
            Email = email;
            Contrasena = contrasena;
            Rol = "Empleado";
        }

        public void Validar()
        {
            if (NombreCompleto is null)
                throw new Exception("El nombre completo no puede estar vacío.");

            if (string.IsNullOrEmpty(Email))
                throw new Exception("El email no puede estar vacío.");

            if (string.IsNullOrEmpty(Contrasena))
                throw new Exception("La contraseña no puede estar vacía.");

            if (string.IsNullOrEmpty(Rol))
                throw new Exception("El rol no puede estar vacío.");
        }
    }
}
