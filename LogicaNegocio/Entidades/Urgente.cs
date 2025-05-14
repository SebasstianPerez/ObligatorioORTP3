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
        public Boolean? Eficiencia { get; set; }
        public DateTime? FechaSalida { get; set; }
        //martillar cuando se crea

        public Urgente() : base()
        {
            FechaSalida = DateTime.Now;
        }

        public Urgente(Usuario empleado, Usuario cliente, double peso, List<Seguimiento> seguimiento, string tipoEnvio, string direccionPostal, int? eficiencia) : base(empleado, cliente, peso, seguimiento, tipoEnvio)
        {
            DireccionPostal = direccionPostal;
            FechaSalida = DateTime.Now;
        }

        public override void FinalizarEnvio()
        {
            base.FinalizarEnvio();

            DateTime fechaFinal = Seguimiento.Last().Fecha;
            TimeSpan duracion = new TimeSpan(0, 24, 0, 0, 0);
                

            if (FechaSalida.Value - fechaFinal < duracion)
            {
                Eficiencia = true;
            }
            else
            {
                Eficiencia = false;
            }
        }
    }
}
