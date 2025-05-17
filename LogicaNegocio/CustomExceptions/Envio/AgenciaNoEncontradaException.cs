using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CustomExceptions.Envio
{
    public class AgenciaNoEncontradaException : Exception
    {
        public AgenciaNoEncontradaException()
        {

        }

        public AgenciaNoEncontradaException(string message) : base(message) { }

        public AgenciaNoEncontradaException(string message, Exception? innerException) : base(message, innerException) { }
    }
}
