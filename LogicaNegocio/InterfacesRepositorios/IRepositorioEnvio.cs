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

        List<Envio> FindByClienteEmail(String email);

        List<Envio> GetEnviosClientePorFecha(String email, DateTime fecha1, DateTime fecha2);

        List<Envio> GetEnviosClientePorComentario(String email, string comentario);
    }
}
