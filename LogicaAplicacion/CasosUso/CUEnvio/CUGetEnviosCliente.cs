using DTOs.DTOs.Envio;
using DTOs.Mapper;
using LogicaAplicacion.ICasosUso.ICUEnvio;
using LogicaNegocio.CustomExceptions.Envio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUGetEnviosCliente : ICUGetEnviosCliente
    {
        private readonly IRepositorioEnvio _repositorioEnvio;

        public CUGetEnviosCliente(IRepositorioEnvio repositorioEnvio)
        {
            _repositorioEnvio = repositorioEnvio;
        }

        public List<DTOEnvio> Ejecutar(string email)
        {
            List<DTOEnvio> ret = new List<DTOEnvio>();

            ret = EnvioMapper.ToListDTOEnvio(_repositorioEnvio.FindByClienteEmail(email));

            //ordenarPorFechaConJS

            if (ret is null || ret.Count == 0)
                throw new ClienteEnvioNullException("No se encontraron envíos para el cliente especificado.");

            return ret;
        }
    }
}
