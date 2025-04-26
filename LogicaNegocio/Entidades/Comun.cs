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

        public Comun(string numTracking, Usuario empleado, Usuario cliente, double peso, List<Seguimiento> seguimiento, string tipoEnvio, Agencia agencia) : base(numTracking, empleado, cliente, peso, seguimiento, tipoEnvio)
        {
            agencia = agencia;
        }
    }
}
