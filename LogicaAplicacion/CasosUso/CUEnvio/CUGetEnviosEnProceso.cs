using DTOs.DTOs.Envio;
using DTOs.Mapper;
using LogicaAplicacion.ICasosUso.ICUEnvio;
using LogicaNegocio.CustomExceptions.Envio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUGetEnviosEnProceso : ICUGetEnviosEnProceso
    {
        private readonly IRepositorioEnvio _repositorioEnvio;

        public CUGetEnviosEnProceso(IRepositorioEnvio repositorioEnvio)
        {
            _repositorioEnvio = repositorioEnvio;
        }

        public List<DTOEnvio> Ejecutar()
        {
            List<DTOEnvio> ret = new List<DTOEnvio>();
            var envios = _repositorioEnvio.GetEnviosEnProceso();

            if (envios == null)
                throw new EnvioNoExisteException("No hay envios disponibles");

            ret = EnvioMapper.ToListDTOEnvio(envios);

            return ret;
        }
    }
}
