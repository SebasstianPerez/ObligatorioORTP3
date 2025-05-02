using System.ComponentModel.DataAnnotations;

namespace LogicaAplicacion.ICasosUso.ICUUsuario
{
    public class DTOEditarUsuarioRequest
    {
        public int loguadoId { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre no puede ser vacio")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo puede contener letras y espacios")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido no puede ser vacio")]
        [StringLength(50, ErrorMessage = "El apellido no puede exceder los 50 caracteres")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El apellido solo puede contener letras y espacios")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El rol no puede ser vacio")]
        public string Rol { get; set; }
        [Required(ErrorMessage = "El email no puede ser vacio")]
        [EmailAddress(ErrorMessage = "El email no es válido")]
        [StringLength(100, ErrorMessage = "El email no puede exceder los 100 caracteres")]
        public string Email { get; set; }

        public DTOEditarUsuarioRequest()
        {
            
        }

        public DTOEditarUsuarioRequest(string nombre, string apellido, string rol, string email)
        {
            Nombre = nombre;
            Apellido = apellido;
            Rol = rol;
            Email = email;
        }
    }
}