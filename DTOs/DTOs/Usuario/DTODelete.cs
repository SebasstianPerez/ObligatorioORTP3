using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.Usuario
{
    public class DTODelete
    {
        [Required(ErrorMessage = "El id no puede ser nulo")]
        public int UsuarioId { get; set; }
        
        [Required]
        public int LogueadoId { get; set; }

        public DTODelete()
        {
            
        }

        public DTODelete(int usuarioId, int logueadoId)
        {
            UsuarioId = usuarioId;
            LogueadoId = logueadoId;
        }
    }
}
