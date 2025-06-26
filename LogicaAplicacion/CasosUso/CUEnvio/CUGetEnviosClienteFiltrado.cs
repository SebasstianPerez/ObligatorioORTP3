using DTOs.DTOs;
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
    public class CUGetEnviosClienteFiltrado : ICUGetEnviosClienteFiltrado
    {
        private readonly IRepositorioEnvio _repositorioEnvio;

        public CUGetEnviosClienteFiltrado(IRepositorioEnvio repositorioEnvio)
        {
            _repositorioEnvio = repositorioEnvio;
        }

        public DTOPaginado<DTOEnvio> Ejecutar(DTOFiltro? dto)
        {
            if (dto.Email.IsNullOrEmpty())
                throw new UsuarioNoEncontradoException("Email invalido");

            if (dto.FechaDesde != null && dto.FechaHasta != null && dto.FechaDesde > dto.FechaHasta)
                throw new ArgumentException("La fecha de inicio debe ser menor a la fecha de fin");

            DTOPaginado<DTOEnvio> ret = new DTOPaginado<DTOEnvio>();

            ret = EnvioMapper.ToListPaginacion(_repositorioEnvio.GetEnviosCliente(dto.Email, dto.FechaDesde, dto.FechaHasta, dto.Estado, dto.Comentario, dto.Page, dto.PageSize));

            return ret;
        }
    }
}
