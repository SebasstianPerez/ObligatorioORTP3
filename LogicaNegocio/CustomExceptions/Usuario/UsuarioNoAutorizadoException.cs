using System;

namespace LogicaNegocio.CustomExceptions.UsuarioException
{
    public class UsuarioNoAutorizadoException : Exception
    {
        public UsuarioNoAutorizadoException()
            : base("Usuario no autorizado para realizar esta acción.")
        {
        }

        public UsuarioNoAutorizadoException(string message)
            : base(message)
        {
        }

        public UsuarioNoAutorizadoException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
