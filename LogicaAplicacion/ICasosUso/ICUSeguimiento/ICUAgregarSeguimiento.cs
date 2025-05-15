using DTOs.DTOs.Envio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ICasosUso.ICUSeguimiento
{
    public interface ICUAgregarSeguimiento
    {
        void Ejecutar(DTOSeguimiento dto);
    }
}
