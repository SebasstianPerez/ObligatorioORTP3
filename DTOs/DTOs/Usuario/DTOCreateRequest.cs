﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.Usuario
{
    public class DTOCreateRequest
    {
        [Required(ErrorMessage = "El nombre no puede ser vacio")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo puede contener letras y espacios")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(50, ErrorMessage = "El apellido no puede exceder los 50 caracteres")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El apellido solo puede contener letras y espacios")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "La contraseña no puede ser vacia")]
        [StringLength(100, ErrorMessage = "La contraseña debe tener al menos 8 caracteres", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }

        public int LogueadoId { get; set; }
    }
}
