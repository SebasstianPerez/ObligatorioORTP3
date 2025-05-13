using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.Agencia
{
    public class DTOAgencia
    {
        public string Nombre { get; set; }
        public string DireccionPostal { get; set; }
        public string Telefono { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }

        public DTOAgencia(string nombre, string direccionPostal, string telefono, string latitud, string longitud)
        {
            Nombre = nombre;
            DireccionPostal = direccionPostal;
            Telefono = telefono;
            Latitud = latitud;
            Longitud = longitud;
        }

        public DTOAgencia()
        {
            
        }
    }
}
