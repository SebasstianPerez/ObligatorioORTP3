using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CustomExceptions.Envio
{
    public class ClienteEnvioNullException : Exception
    {
        public ClienteEnvioNullException() { }

        public ClienteEnvioNullException(string message) : base(message) { }

        public ClienteEnvioNullException(string message, Exception? innerException) : base(message, innerException) { }
    }
}
