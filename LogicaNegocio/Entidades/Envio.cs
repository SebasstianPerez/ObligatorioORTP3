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
        public string NumeroTracking { get; set; }
        public Usuario Empleado { get; set; }
        public Usuario Cliente { get; set; }
        public Double Peso { get; set; }
        public Estado? Estado { get; set; }

        public List<Seguimiento> Seguimiento { get; set; }

        public Envio(string numTracking, Usuario empleado, Usuario cliente, double peso, List<Seguimiento> seguimiento)
        {
            NumeroTracking = numTracking;
            Empleado = empleado;
            Cliente = cliente;
            Peso = peso;
            Estado = global::Estado.EN_PROCESO;
            Seguimiento = seguimiento;

        }

        public Envio()
        {
            
        }
    }
}
