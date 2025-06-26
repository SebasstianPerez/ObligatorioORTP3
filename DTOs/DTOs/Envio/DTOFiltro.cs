using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.Envio
{
    public class DTOFiltro
    {
        public string? Email { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public string? Estado { get; set; }
        public string? Comentario { get; set; }

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public DTOFiltro()
        {

        }

        public DTOFiltro(DateTime? fechaDesde, DateTime? fechaHasta, string? estado, string? comentario)
        {
            FechaDesde = fechaDesde;
            FechaHasta = fechaHasta;
            Estado = estado;
            Comentario = comentario;
        }
    }
}
