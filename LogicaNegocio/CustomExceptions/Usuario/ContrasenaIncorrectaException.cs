using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CustomExceptions.Usuario
{
    public class ContrasenaIncorrectaException : Exception
    {
        public ContrasenaIncorrectaException()
        {

        }

        public ContrasenaIncorrectaException(string? message) : base(message)
        {

        }

        public ContrasenaIncorrectaException(string? message, Exception? innerException) : base(message, innerException)
        {

        }

    }
}
