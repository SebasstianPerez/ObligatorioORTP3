using LogicaAplicacion.ICasosUso.ICUUsuario;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using DTOs.DTOs.Usuario;

namespace LogicaAplicacion.CasosUso.CUUsuaio
{
    public class CUBajaUsuario : ICUBajaUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IRepositorioAuditoria _repositorioAuditoria;

        public CUBajaUsuario(IRepositorioUsuario repositorioUsuario, IRepositorioAuditoria repositorioAuditoria)
        {
            _repositorioUsuario = repositorioUsuario;
            _repositorioAuditoria = repositorioAuditoria;
        }

        public void Ejecutar(DTODelete dto)
        {
            Usuario u = _repositorioUsuario.findById(dto.UsuarioId);
            if (u is null)
                throw new UsuarioNoEncontradoException("El usuario no existe");

            _repositorioUsuario.Delete(u);

            Auditoria auditoria = new Auditoria("Delete", JsonSerializer.Serialize(u), dto.LogueadoId, "Usuario", u.Id);
            _repositorioAuditoria.Add(auditoria);
        }
    }
}
