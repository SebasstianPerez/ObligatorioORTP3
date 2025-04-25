using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.Usuario
{
    public class DTOUsuario
    {
        public int ID { get; set; }
        public string Rol { get; set; }

        public DTOUsuario() { }

        public DTOUsuario(int iD, string rol)
        {
            ID = iD;
            Rol = rol;
        }
    }
}
