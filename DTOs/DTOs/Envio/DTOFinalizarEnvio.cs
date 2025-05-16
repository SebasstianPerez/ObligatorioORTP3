using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.Envio
{
    public class DTOFinalizarEnvio
    {
        [Required]
        public int EnvioId { get; set; }
        [Required]
        public int LogueadoId { get; set; }

        public DTOFinalizarEnvio()
        {
            
        }

        public DTOFinalizarEnvio(int envioId, int logueadoId)
        {
            EnvioId = envioId;
            LogueadoId = logueadoId;
        }
    }
}
