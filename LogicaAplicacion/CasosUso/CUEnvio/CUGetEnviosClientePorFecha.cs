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
    public class CUGetEnviosClientePorFecha : ICUGetEnviosClientePorFecha
    {
        private readonly IRepositorioEnvio _repoEnvio;

        public CUGetEnviosClientePorFecha(IRepositorioEnvio repoEnvio)
        {
            _repoEnvio = repoEnvio;
        }

        public List<DTOEnvio> Ejecutar(string email, DateTime fecha1, DateTime fecha2)
        {
            List<DTOEnvio> ret = new List<DTOEnvio>();
            
            ret = EnvioMapper.ToListDTOEnvio(_repoEnvio.GetEnviosClientePorFecha(email, fecha1, fecha2));

            if (ret is null || ret.Count == 0)
                throw new EnvioNoExisteException("No se encontraron envíos para el cliente en el rango de fechas especificado.");

            return ret;
        }
    }
}
