using DTOs.DTOs.Usuario;
using LogicaAplicacion.ICasosUso.ICUUsuario;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.CustomExceptions;
using LogicaNegocio.CustomExceptions.Usuario;

namespace LogicaAplicacion.CasosUso.CUUsuaio
{
    public class CULogin : ICULogin
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public CULogin(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public DTOLoginResponse ValidarDatosLogin(DTOLoginRequest dto)
        {
            try
            {
                Usuario usuario = _repositorioUsuario.FindByEmail(dto.Email);

                if (usuario is null)
                    throw new UsuarioNoEncontradoException("Email no encontrado");                

                if (!Crypto.VerifyPasswordConBcrypt(dto.Contrasena, usuario.Contrasena))
                    throw new Exception("Contraeña invalida");

                //devolver dto con id y rol para el cliente
                DTOLoginResponse ret = new();
                ret.ID = usuario.Id;
                ret.Rol = usuario.Rol;

                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
