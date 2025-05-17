using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.Agencia
{
    public class DTOAgencia
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La direccion postal es obligatoria")]
        public string DireccionPostal { get; set; }
        [Required(ErrorMessage = "El telefono es obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage ="La latitud es obligatoria")]
        public string Latitud { get; set; }
        [Required(ErrorMessage = "La longitud es obligatoria")]
        public string Longitud { get; set; }

        public DTOAgencia(int id, string nombre, string direccionPostal, string telefono, string latitud, string longitud)
        {
            Id = id;
            Nombre = nombre;
            DireccionPostal = direccionPostal;
            Telefono = telefono;
            Latitud = latitud;
            Longitud = longitud;
        }

        public DTOAgencia()
        {
            
        }
    }
}
