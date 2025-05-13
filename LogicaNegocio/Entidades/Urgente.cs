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
        public string DireccionPostal { get; set; }
        public int? Eficiencia { get; set; }
        public DateTime? HoraSalida { get; set; }

        public Urgente() : base()
        {
            
        }

        public Urgente(Usuario empleado, Usuario cliente, double peso, List<Seguimiento> seguimiento, string tipoEnvio, string direccionPostal, int? eficiencia, DateTime? horaSalida) : base(empleado, cliente, peso, seguimiento, tipoEnvio)
        {
            DireccionPostal = direccionPostal;
        }
    }
}
