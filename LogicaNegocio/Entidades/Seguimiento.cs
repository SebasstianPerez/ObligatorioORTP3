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
        public Usuario Empleado { get; set; }
        public int EnvioId { get; set; }
        public int EmpleadoId { get; set; }

        public Seguimiento(string? comentario, Usuario empleado, Envio envio)
        {
            Fecha = DateTime.Now;
            Comentario = comentario;
            Empleado = empleado;
            Envio = envio;
        }

        public Seguimiento()
        {
            
        }
    }
}
