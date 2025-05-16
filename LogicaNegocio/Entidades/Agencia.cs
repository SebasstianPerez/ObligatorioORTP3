using LogicaNegocio.CustomExceptions;
using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Agencia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DireccionPostal { get; set; }
        public string Telefono { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }

        public Agencia(int id, string nombre, string direccionPostal, string telefono, string latitud, string longitud)
        {
            Id = id;
            Nombre = nombre;
            DireccionPostal = direccionPostal;
            Telefono = telefono;
            Latitud = latitud;
            Longitud = longitud;
            Validar();
        }

        public Agencia()
        {
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new NombreNoValidoException("El nombre no puede estar vacío.");

            if (Nombre.Length < 3)
                throw new NombreNoValidoException("El nombre debe tener al menos 3 caracteres.");

            if (string.IsNullOrWhiteSpace(Telefono))
                throw new TelefonoNoValidoException("El teléfono no puede estar vacío.");

            if (Telefono.Length < 8)
                throw new TelefonoNoValidoException("El teléfono debe tener al menos 8 caracteres.");

            if (string.IsNullOrWhiteSpace(Latitud))
                throw new DireccionNoValidoException("La latitud no puede estar vacía.");

            if (string.IsNullOrWhiteSpace(Longitud))
                throw new DireccionNoValidoException("La longitud no puede estar vacía.");
        }
    }
}
