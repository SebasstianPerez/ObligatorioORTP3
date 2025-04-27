using DTOs.DTOs.Usuario;
using DTOs.Mapper;
using LogicaAplicacion.ICasosUso.ICUUsuario;
using LogicaNegocio.CustomExceptions;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUUsuaio
{
    public class CUAltaUsuario : ICUAltaUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        //private readonly IRepositorioAuditoria _repositorioAuditoria;

        //TODO Auditoria
        public CUAltaUsuario(IRepositorioUsuario repositorioUsuario /*, IRepositorioAuditoria repositorioAuditoria*/)
        {
            _repositorioUsuario = repositorioUsuario;
            //_repositorioAuditoria = repositorioAuditoria;
        }


        public void Ejecutar(DTOCreateRequest dto)
        {
            Usuario Buscado = _repositorioUsuario.FindByEmail(dto.Email);

            if (Buscado != null)
                throw new UsuarioNoEncontradoException("Ya existe el email en la base de datos");

            Usuario nuevo = UsuarioMapper.ToUsuario(dto);
            int idUsuario = _repositorioUsuario.Add(nuevo);

            //Auditoria con usuarioId y dto.LogueadoId
        }

        //TODO Auditoria
    }
}
