using DTOs.DTOs.Envio;
using DTOs.Mapper;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.ICasosUso.ICUEnvio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUGetEnvios : ICUGetEnvios
    {

        private readonly RepositorioEnvio _repositorioEnvio;

        public CUGetEnvios(RepositorioEnvio repositorioEnvio)
        {
            _repositorioEnvio = repositorioEnvio;
        }

        public List<DTOGetEnvios> Ejecutar()
        {
            List<DTOGetEnvios> ret = new List<DTOGetEnvios>();
            var envios = _repositorioEnvio.GetAll();

            ret = EnvioMapper.ToListDTOEnvio(envios);

            return ret;
        }
    }
}
