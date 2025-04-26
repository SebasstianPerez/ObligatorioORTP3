namespace LogicaNegocio.CustomExceptions
{
    [Serializable]
    public class NombreNoValidoException : Exception
    {
        public NombreNoValidoException()
        {
        }

        public NombreNoValidoException(string? message) : base(message)
        {
        }

        public NombreNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}