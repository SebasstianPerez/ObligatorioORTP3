using DTOs.DTOs.Usuario;
using LogicaAplicacion.ICasosUso.ICUUsuario;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUUsuaio
{
    public class CULogin : ICULogin
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public CULogin(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public DTOUsuario Login(DTOLogin dto)
        {
            try
            {
                Usuario usuario = _repositorioUsuario.FindByEmail(dto.Email);

                //TODO HASHING CRYPTO Utilities
                if (usuario is null)
                    throw new Exception("Usuario no encontrado");

                if (usuario.Contrasena != dto.Contrasena)
                    throw new Exception("Contraeña invalida");

                //devolver dto con id y rol para el cliente
                DTOUsuario ret = new();
                ret.ID = usuario.Id;
                ret.Rol = usuario.Rol;

                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("Error de credenciales: "+ex);
            }
        }
    }
}
