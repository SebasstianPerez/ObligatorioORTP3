using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Urgente : Envio
    {
        public DireccionPostal DireccionPostal { get; set; }
        public int? Eficiencia { get; set; }
        public DateTime HoraSalida { get; set; }

        public Urgente() : base()
        {
            
        }

        public Urgente(string numTracking, Usuario empleado, Usuario cliente, double peso, List<Seguimiento> seguimiento, string tipoEnvio, DireccionPostal direccionPostal, int? eficiencia, DateTime horaSalida) : base(numTracking, empleado, cliente, peso, seguimiento, tipoEnvio)
        {
            DireccionPostal = direccionPostal;
        }
    }
}
