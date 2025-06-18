using DTOs.DTOs.Usuario;
using LogicaAplicacion.ICasosUso.ICUUsuario;
using LogicaNegocio.CustomExceptions.Usuario;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUCambiarContrasena : ICUCambiarContrasena
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public CUCambiarContrasena(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public void Ejecutar(DTOCambiarContrasena dto)
        {

            Usuario cliente = _repositorioUsuario.FindByEmail(dto.Email);

            if (cliente == null)
            {
                throw new UsuarioNoEncontradoException("El usuario no existe.");
            }

            if (!Crypto.VerifyPasswordConBcrypt(dto.ContrasenaActual, cliente.Contrasena))
            {
                throw new ContrasenaIncorrectaException("La contraseña actual es incorrecta.");
            }

            if (dto.NuevaContrasena != dto.ConfirmarContrasena)
            {
                throw new ArgumentException("La nueva contraseña y la confirmación no coinciden.");
            }

            cliente.Contrasena = dto.NuevaContrasena;
            cliente.Validar();

            cliente.Contrasena = Crypto.HashPasswordConBcrypt(dto.NuevaContrasena, 12);
            _repositorioUsuario.Update(cliente);
        }
    }
}
