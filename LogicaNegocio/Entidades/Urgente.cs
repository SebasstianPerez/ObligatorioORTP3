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

        public Urgente() : base()
        {
            FechaSalida = DateTime.Now;
        }

        public Urgente(Usuario empleado, Usuario cliente, double peso, string tipoEnvio, string direccionPostal) : base(empleado, cliente, peso, tipoEnvio)
        {
            DireccionPostal = direccionPostal;
            FechaSalida = DateTime.Now;
            Estado = Estado.EN_PROCESO;
            NumeroTracking = GenerarNumeroTracking();
            Validar();
        }

        public override void FinalizarEnvio(int idEmpleado)
        {
            base.FinalizarEnvio(idEmpleado);

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
        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(DireccionPostal))
                throw new ArgumentNullException("La dirección postal no puede estar vacía.", nameof(DireccionPostal));

            if (FechaSalida == null)
                throw new ArgumentNullException("La fecha de salida no puede ser nula.", nameof(FechaSalida));

            if (FechaSalida > DateTime.Now)
                throw new ArgumentException("La fecha de salida no puede ser futura.", nameof(FechaSalida));
        }

    }
}
