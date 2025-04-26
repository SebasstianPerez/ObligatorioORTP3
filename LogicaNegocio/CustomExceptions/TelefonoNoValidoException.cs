namespace LogicaNegocio.CustomExceptions
{
    [Serializable]
    internal class TelefonoNoValidoException : Exception
    {
        public TelefonoNoValidoException()
        {
        }

        public TelefonoNoValidoException(string? message) : base(message)
        {
        }

        public TelefonoNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}