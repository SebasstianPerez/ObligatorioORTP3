using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CustomExceptions.Envio
{
    public class EnvioFinalizadoException : Exception
    {
        public EnvioFinalizadoException() { }

        public EnvioFinalizadoException(string message) : base(message) { }

        public EnvioFinalizadoException(string message, Exception? innerException) : base(message, innerException) { }
    }
}
