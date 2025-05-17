using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CustomExceptions.Envio
{
    public class NumeroTrackingInvalidoException : Exception
    {
        public NumeroTrackingInvalidoException(string message) : base(message)
        {
        }

        public NumeroTrackingInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public NumeroTrackingInvalidoException() : base("El número de tracking es inválido")
        {
        }


    }
}
