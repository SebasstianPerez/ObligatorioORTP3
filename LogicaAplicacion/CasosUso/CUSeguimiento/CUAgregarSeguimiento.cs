using DTOs.DTOs.Envio;
using LogicaAplicacion.ICasosUso.ICUSeguimiento;
using LogicaNegocio.CustomExceptions;
using LogicaNegocio.CustomExceptions.Envio;
using LogicaNegocio.CustomExceptions.Usuario;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUSeguimiento
{
    public class CUAgregarSeguimiento : ICUAgregarSeguimiento
    {
        private readonly IRepositorioSeguimiento _repositorioSeguimiento;
        private readonly IRepositorioEnvio _repositorioEnvio;
        private readonly IRepositorioUsuario _repositorioUsuario;

        public CUAgregarSeguimiento(IRepositorioSeguimiento repositorioSeguimiento, IRepositorioEnvio repositorioEnvio, IRepositorioUsuario repositorioUsuario)
        {
            _repositorioSeguimiento = repositorioSeguimiento;
            _repositorioEnvio = repositorioEnvio;
            _repositorioUsuario = repositorioUsuario;
        }

        public void Ejecutar(DTOSeguimiento dto)
        {
            Envio envio = _repositorioEnvio.findById(dto.EnvioId);
            if (envio == null) {
                throw new EnvioNoExisteException("El envio no existe");
            }
            
            Usuario empleado = _repositorioUsuario.findById(dto.EmpleadoId);
            if (empleado == null) {
                throw new UsuarioNoEncontradoException("El empleado no existe");
            }

            _repositorioSeguimiento.Add(new Seguimiento(dto.Comentario, empleado.Id, envio));
        }
    }
}
