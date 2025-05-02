using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Auditoria
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int LogueadoId { get; set; }
        public string? Accion { get; set; }
        public string? Entidad { get; set; }
        public int? EntidadId { get; set; }
        public string? Data { get; set; }
        

        public Auditoria(string? accion, string? data, int logueadoId, string? entidad, int? entidadId)
        {
            Fecha = DateTime.Now;
            Accion = accion;
            Data = data;
            LogueadoId = logueadoId;
            Entidad = entidad;
            EntidadId = entidadId;
        }
    }
}
