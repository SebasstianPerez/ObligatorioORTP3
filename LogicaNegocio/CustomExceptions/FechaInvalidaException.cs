using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CustomExceptions
{
    public class FechaInvalidaException : Exception
    {
        public FechaInvalidaException() { }

        public FechaInvalidaException(string message) : base(message) { }

        public FechaInvalidaException(string message, Exception inner) : base(message, inner) { }
    }
}
