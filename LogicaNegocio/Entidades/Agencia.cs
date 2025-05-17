using LogicaNegocio.CustomExceptions;
using LogicaNegocio.CustomExceptions.Usuario;
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
        public Ubicacion Ubicacion { get; set; } = new Ubicacion();

        public Agencia(int id, string nombre, string direccionPostal, string telefono, Ubicacion ubicacion)
        {
            Id = id;
            Nombre = nombre;
            DireccionPostal = direccionPostal;
            Telefono = telefono;
            Ubicacion = ubicacion;
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

            if (string.IsNullOrWhiteSpace(Ubicacion.Latitud))
                throw new DireccionNoValidoException("La latitud no puede estar vacía.");

            if (string.IsNullOrWhiteSpace(Ubicacion.Longitud))
                throw new DireccionNoValidoException("La longitud no puede estar vacía.");
        }
    }
}
