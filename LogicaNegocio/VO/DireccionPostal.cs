namespace LogicaNegocio.VO
{
    public class DireccionPostal
    {
        public string Calle { get; init; }
        public string NumCalle { get; set; }
        public string Ciudad { get; init; }
        public string CodigoPostal { get; init; }

        public DireccionPostal()
        {
            
        }

        public DireccionPostal(string calle, string ciudad, string codigoPostal, string numCalle)
        {
            Calle = calle;
            Ciudad = ciudad;
            CodigoPostal = codigoPostal;
            NumCalle = numCalle;
        }

        //TODO EXCEPTIONS
    }
}