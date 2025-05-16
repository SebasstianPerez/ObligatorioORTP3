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
            Validar();
        }

        public Auditoria()
        {
            
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Accion))
                throw new ArgumentException("La acción no puede estar vacía.", nameof(Accion));

            if (string.IsNullOrWhiteSpace(Entidad))
                throw new ArgumentException("La entidad no puede estar vacía.", nameof(Entidad));

            if (EntidadId == null || EntidadId <= 0)
                throw new ArgumentException("El ID de la entidad debe ser un número positivo.", nameof(EntidadId));

            if (LogueadoId <= 0)
                throw new ArgumentException("El ID del usuario logueado debe ser un número positivo.", nameof(LogueadoId));
        }


    }
}
