using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Seguimiento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? Comentario { get; set; }
        public Envio Envio { get; set; }
        public int EnvioId { get; set; }
        public Usuario? Empleado { get; set; }
        public int EmpleadoId { get; set; }

        public Seguimiento(string? comentario, int empleadoId, Envio envio)
        {
            Fecha = DateTime.Now;
            Comentario = comentario;
            EmpleadoId = empleadoId;
            Envio = envio;
            Validar();
        }

        public Seguimiento()
        {
            
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Comentario))
                throw new ArgumentNullException("El comentario no puede ser nulo ni vacío.", nameof(Comentario));

            if (Envio == null)
                throw new ArgumentNullException(nameof(Envio), "El envío no puede ser nulo.");
        }

    }
}
