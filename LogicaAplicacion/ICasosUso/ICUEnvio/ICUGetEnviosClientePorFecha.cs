using DTOs.DTOs.Envio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ICasosUso.ICUEnvio
{
    public interface ICUGetEnviosClientePorFecha
    {
        List<DTOEnvio> Ejecutar(String email, Estado? estado, DateTime fecha1, DateTime fecha2);
    }
}
