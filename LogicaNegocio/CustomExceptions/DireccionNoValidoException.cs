namespace LogicaNegocio.CustomExceptions
{
    [Serializable]
    internal class DireccionNoValidoException : Exception
    {
        public DireccionNoValidoException()
        {
        }

        public DireccionNoValidoException(string? message) : base(message)
        {
        }

        public DireccionNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}