using DTOs.DTOs.Envio;
using DTOs.Mapper;
using LogicaAplicacion.ICasosUso.ICUEnvio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUGetEnvios : ICUGetEnvios
    {

        private readonly IRepositorioEnvio _repositorioEnvio;

        public CUGetEnvios(IRepositorioEnvio repositorioEnvio)
        {
            _repositorioEnvio = repositorioEnvio;
        }

        public List<DTOEnvio> Ejecutar()
        {
            List<DTOEnvio> ret = new List<DTOEnvio>();
            var envios = _repositorioEnvio.GetAll();

            ret = EnvioMapper.ToListDTOEnvio(envios);

            return ret;
        }
    }
}
