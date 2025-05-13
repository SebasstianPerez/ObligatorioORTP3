using LogicaAplicacion.ICasosUso.ICUEnvio;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUFinalizarEnvio : ICUFinalizarEnvio
    {
        private readonly IRepositorioEnvio _repositorioEnvio;

        public CUFinalizarEnvio(IRepositorioEnvio repositorioEnvio)
        {
            _repositorioEnvio = repositorioEnvio;
        }

        public void Ejecutar(int idEnvio, int LogueadoId)
        {
            Envio envio = _repositorioEnvio.findById(idEnvio);
            if (envio == null)
                throw new Exception("El envio no existe");
            
            if (envio.Estado == Estado.FINALIZADO)
                throw new Exception("El envio ya esta FINALIZADO");
            else
            {
                envio.Estado = Estado.FINALIZADO;
                _repositorioEnvio.Update(envio);
                /*
                 envio.Seguimiento.Add(new Seguimiento()
                {
                    Comentario = Estado.FINALIZADO.ToString(),
                    EmpleadoId = LogueadoId,
                    Envio = envio
                });
                 */
            }
        }
    }
}
