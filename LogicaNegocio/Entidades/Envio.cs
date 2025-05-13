using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Envio
    {
        public int Id { get; set; }
        public string? NumeroTracking { get; set; }
        public Usuario Empleado { get; set; }
        public Usuario Cliente { get; set; }
        public Double Peso { get; set; }
        public Estado Estado { get; set; }
        public int? AgenciaId { get; set; }

        public List<Seguimiento> Seguimiento { get; set; }
        public string TipoEnvio { get; set; }

        public Envio(Usuario empleado, Usuario cliente, double peso, List<Seguimiento> seguimiento, string tipoEnvio)
        {
            Empleado = empleado;
            Cliente = cliente;
            Peso = peso;
            Estado = global::Estado.EN_PROCESO;
            Seguimiento = seguimiento;
            TipoEnvio = tipoEnvio;
        }

        public Envio()
        {
        }

        public string GenerarNumeroTracking()
        {
            Guid guid = Guid.NewGuid();
            string tracking = guid.ToString();
            tracking += DateTime.Now.ToString("d") + Id;
            return tracking;
        }
    }
}
