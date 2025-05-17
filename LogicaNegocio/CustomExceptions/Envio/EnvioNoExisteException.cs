using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CustomExceptions.Envio
{
    public class EnvioNoExisteException : Exception
    { 
        public EnvioNoExisteException() { }

        public EnvioNoExisteException(string message) : base(message) { }

        public EnvioNoExisteException(string message, Exception? innerException) : base(message, innerException) { }

    }
}
