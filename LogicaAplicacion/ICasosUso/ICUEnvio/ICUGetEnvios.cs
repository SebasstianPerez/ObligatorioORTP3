using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.DTOs.Envio;

namespace LogicaAplicacion.ICasosUso.ICUEnvio
{
    public interface ICUGetEnvios
    {
        List<DTOEnvio> Ejecutar();
    }
}
