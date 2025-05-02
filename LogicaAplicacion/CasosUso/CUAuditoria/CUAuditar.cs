using LogicaAplicacion.ICasosUso.ICUAuditoria;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUAuditoria
{
    public class CUAuditar : ICUAuditar
    {
        private readonly IRepositorioAuditoria _repositorioAuditoria;

        public CUAuditar(IRepositorioAuditoria repositorioAuditoria)
        {
            _repositorioAuditoria = repositorioAuditoria;
        }

        public void Ejecutar(string? accion, string? data, int logueadoId, string? entidad, int? entidadId)
        {
            _repositorioAuditoria.Add(new Auditoria(accion, data, logueadoId, entidad, entidadId));
        }
    }
}
