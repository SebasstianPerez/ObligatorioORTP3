using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.Usuario
{
    public class DTOLoginResponse
    {
        public int ID { get; set; }
        public string Rol { get; set; }
        public string? Email { get; set; }
        

        public DTOLoginResponse() { }

        public DTOLoginResponse(int iD, string rol)
        {
            ID = iD;
            Rol = rol;
        }
    }
}
