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
        }

        public Agencia()
        {
            Validar();
        }

        public void Validar()
        {
            if (Nombre == null || Nombre == "")
            {
                throw new NombreNoValidoException();
            }

            if (Nombre.Length < 3)
            {
                throw new NombreNoValidoException();
            }

            if (Telefono == null || Telefono == "")
            {
                throw new TelefonoNoValidoException();
            }

            if (Telefono.Length < 8)
            {
                throw new TelefonoNoValidoException();
            }

            if (Latitud == null || Latitud == "")
            {
                throw new DireccionNoValidoException();
            }

            //if (Latitud.Length < ...)
            //{
            //    throw new DireccionNoValidoException();
            //}

            if (Longitud == null || Longitud == "")
            {
                throw new DireccionNoValidoException();
            }

            //if (Logitud.Length < ...)
            //{
            //    throw new DireccionNoValidoException();
            //}


            //TODO Exepcions
        }
    }
}
