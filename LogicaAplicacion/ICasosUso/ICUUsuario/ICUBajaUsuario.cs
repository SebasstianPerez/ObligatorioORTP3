using DTOs.DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ICasosUso.ICUUsuario
{
    public interface ICUBajaUsuario
    {
        void Ejecutar(DTODelete dto);
    }
}
