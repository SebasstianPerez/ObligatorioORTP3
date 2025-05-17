using LogicaNegocio.CustomExceptions;
using LogicaNegocio.CustomExceptions.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.VO
{
    public class NombreCompleto
    {
        public string Nombre { get; init; }
        public string Apellido { get; init; }

        public NombreCompleto(string nombre, string apellido) {
        
            Nombre = nombre;
            Apellido = apellido;
        }

        public void Validar()
        {
            if (String.IsNullOrEmpty(Nombre))
            {
                throw new NombreNoValidoException("El campo nombre no puede ser nulo.");
            }

            if (String.IsNullOrEmpty(Apellido))
            {
                throw new NombreNoValidoException("El campo apellido no puede ser nulo.");
            }
        }

        public override string ToString()
        {
            return Nombre + " " + Apellido;
    }
}
}
