using DTOs.DTOs.Envio;
using DTOs.Mapper;
using LogicaAplicacion.ICasosUso.ICUEnvio;
using LogicaNegocio.CustomExceptions.Envio;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUGetEnvio : ICUGetEnvio
    {
        private readonly IRepositorioEnvio _repositorioEnvio;

        public CUGetEnvio(IRepositorioEnvio repositorioEnvio)
        {
            _repositorioEnvio = repositorioEnvio;
        }

        public DTOEnvio Ejecutar(int EnvioId)
        {
            Envio envio = _repositorioEnvio.findById(EnvioId);

            if (envio == null)
                throw new EnvioNoExisteException("El envio no existe");

            DTOEnvio ret = EnvioMapper.ToDTOEnvio(envio);

            return ret;
        }
    }
}
