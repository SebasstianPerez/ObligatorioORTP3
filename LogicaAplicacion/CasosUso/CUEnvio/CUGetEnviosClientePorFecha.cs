using DTOs.DTOs.Envio;
using DTOs.Mapper;
using LogicaAplicacion.ICasosUso.ICUEnvio;
using LogicaNegocio.CustomExceptions;
using LogicaNegocio.CustomExceptions.Envio;
using LogicaNegocio.CustomExceptions.Usuario;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.IdentityModel.Tokens;
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

            if (email.IsNullOrEmpty())
                throw new UsuarioNoEncontradoException("Email invalido");

            if (fecha1 == null)
                throw new FechaInvalidaException("Las fechas no pueden ser nulas.");

            if (fecha1 > fecha2)
                throw new ArgumentException("La fecha de inicio debe ser menor a la fecha de fin");
            
            ret = EnvioMapper.ToListDTOEnvio(_repoEnvio.GetEnviosClientePorFecha(email, fecha1, fecha2));

            if (ret is null || ret.Count == 0)
                throw new EnvioNoExisteException("No se encontraron envíos para el cliente en el rango de fechas especificado.");

            return ret;
        }
    }
}
