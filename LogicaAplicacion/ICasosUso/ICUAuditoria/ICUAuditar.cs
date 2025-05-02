using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ICasosUso.ICUAuditoria
{
    public interface ICUAuditar
    {
        void Ejecutar(string? accion, string? data, int logueadoId, string? entidad, int? entidadId);
    }
}
