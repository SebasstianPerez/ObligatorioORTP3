using LogicaNegocio.Core;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEnvio : IRepositorio<Envio>
    {
        public Envio findByNroTracking(string nroTracking);

        List<Envio> GetEnviosEnProceso();

        PaginacionResultado<Envio> GetEnviosCliente(string email, DateTime? fecha1, DateTime? fecha2, string? estado, string? comentario, int page, int pageSize);
    }
}
