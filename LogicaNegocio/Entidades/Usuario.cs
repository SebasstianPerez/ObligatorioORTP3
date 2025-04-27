using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public Usuario() {
            
        }

        public Usuario(NombreCompleto nombreCompleto, string email, string contrasena)
        {
            NombreCompleto = nombreCompleto;
            Email = email;
            Contrasena = contrasena;
            Rol = "Empleado";
            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Email))
                throw new Exception("El email no puede estar vacío");

            if (!Regex.IsMatch(Email, @"^[\w\.-]+@[\w\.-]+\.\w{2,6}$"))
                throw new Exception("El email debe ir con formato correcto");

            if (string.IsNullOrEmpty(Contrasena))
                throw new Exception("La contraseña no puede estar vacía");

            if (Contrasena.Length < 8)
                throw new Exception("La contraseña debe tener 8 o mas caracteres");

            if (!Contrasena.Any(char.IsUpper))
                throw new Exception("La contraseña debe tener una mayuscula");

            if (!Contrasena.Any(char.IsLower))
                throw new Exception("La contraseña debe tener una minuscula");

            if(!Contrasena.Any(char.IsDigit))
                throw new Exception("La contraseña debe tener un numero");

            if (!Regex.IsMatch(Contrasena, @"[@$!%*?&]"))
                Console.WriteLine("La contraseña debe contener al menos un carácter especial (@$!%*?&)");
        }
    }
}
