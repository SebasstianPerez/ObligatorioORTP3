using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.Usuario
{
    public class DTOCambiarContrasena
    {
        public string Email { get; set; }
        public string ContrasenaActual { get; set; }
        public string NuevaContrasena { get; set; }
        public string ConfirmarContrasena { get; set; }

        public DTOCambiarContrasena()
        {

        }
    }
}
