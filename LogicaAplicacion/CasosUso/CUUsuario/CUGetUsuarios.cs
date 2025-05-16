using DTOs.DTOs.Usuario;
using DTOs.Mapper;
using LogicaAplicacion.ICasosUso.ICUUsuario;
using LogicaNegocio.CustomExceptions;
using LogicaNegocio.CustomExceptions.Usuario;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUGetUsuarios : ICUGetUsuarios
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public CUGetUsuarios(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public List<DTOUsuario> Ejecutar()
        {
            List<DTOUsuario> ret = new();
            List<Usuario> usuarios = _repositorioUsuario.GetAll();

            if (usuarios == null)
                throw new UsuarioNoEncontradoException("No hay usuarios disponibles");

            ret = UsuarioMapper.ToListDTOUsuario(usuarios);

            return ret;
        }
    }
}
