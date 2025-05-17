using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.VO
{
    public class Ubicacion
    {
        public string Latitud { get; set; }
        public string Longitud { get; set; }

        public Ubicacion(string latitud, string longitud)
        {
            Latitud = latitud;
            Longitud = longitud;
        }

        public Ubicacion()
        {
            
        }
    }
}
