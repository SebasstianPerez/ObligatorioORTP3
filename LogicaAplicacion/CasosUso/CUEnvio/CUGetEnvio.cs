using DTOs.DTOs.Envio;
using DTOs.Mapper;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.ICasosUso.ICUEnvio;
using LogicaNegocio.Entidades;
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
        private readonly RepositorioEnvio _repositorioEnvio;

        public CUGetEnvio(RepositorioEnvio repositorioEnvio)
        {
            _repositorioEnvio = repositorioEnvio;
        }

        public DTOGetEnvios Ejecutar(int EnvioId)
        {
            DTOGetEnvios ret = EnvioMapper.ToDTOEnvio(_repositorioEnvio.findById(EnvioId));

            return ret;
        }
    }
}
