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
    public class CUGetDatosUsuario : ICUGetDatosUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public CUGetDatosUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public DTOUsuario Ejecutar(int id)
        {
            Usuario u = _repositorioUsuario.findById(id);

            if (u is null)
                throw new UsuarioNoEncontradoException("El usuario no existe");

            var ret = UsuarioMapper.ToDTOUsuario(u);

            return ret;
        }
    }
}
