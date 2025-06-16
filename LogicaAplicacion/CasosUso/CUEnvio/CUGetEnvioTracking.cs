using DTOs.DTOs.Envio;
using DTOs.Mapper;
using LogicaAplicacion.ICasosUso.ICUEnvio;
using LogicaNegocio.CustomExceptions.Envio;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUGetEnvioTracking : ICUGetEnvioTracking
    {
        private readonly IRepositorioEnvio _repositorioEnvio;

        public CUGetEnvioTracking(IRepositorioEnvio repositorioEnvio)
        {
            _repositorioEnvio = repositorioEnvio;
        }
        public DTOEnvio Ejecutar(string nroTracking)
        {
            if (string.IsNullOrEmpty(nroTracking))
            {
                throw new NumeroTrackingInvalidoException("El número de tracking no puede ser nulo o vacío");
            }

            Envio envio = _repositorioEnvio.findByNroTracking(nroTracking);

            DTOEnvio ret = EnvioMapper.ToDTOEnvio(envio);

            return ret;
        }
    }
}
