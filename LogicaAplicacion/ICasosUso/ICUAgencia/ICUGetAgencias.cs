using DTOs.DTOs.Agencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ICasosUso.ICUAgencia
{
    public interface ICUGetAgencias
    {
        public List<DTOAgencia> Ejecutar();
    }
}
