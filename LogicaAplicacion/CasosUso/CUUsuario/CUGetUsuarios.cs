using DTOs.DTOs.Usuario;
using DTOs.Mapper;
using LogicaAplicacion.ICasosUso.ICUUsuario;
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

        public List<DTOListUsuarios> Ejecutar()
        {
            List<DTOListUsuarios> ret = new();

            ret = UsuarioMapper.ToListDTOUsuario(_repositorioUsuario.GetAll());

            return ret;
        }
    }
}
