using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Comun : Envio
    {
        public Agencia agencia { get; set; }

        public Comun(): base()
        {
            
        }

        public Comun(Usuario empleado, Usuario cliente, double peso, string tipoEnvio, Agencia agencia) : base(empleado,cliente, peso, tipoEnvio)
        {
            agencia = agencia;
            Estado = Estado.EN_PROCESO;
            NumeroTracking = GenerarNumeroTracking();
            agregarSeguimiento("Ingresado en agencia de origen", EmpleadoId);
            Validar();
        }

        public void Validar()
        {
            if (agencia == null)
                throw new ArgumentException("La agencia no puede estar vacía.", nameof(agencia));
        }
    }
}
