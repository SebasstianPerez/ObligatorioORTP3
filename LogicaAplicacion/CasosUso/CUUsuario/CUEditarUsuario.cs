using DTOs.Mapper;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.ICasosUso.ICUUsuario;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUUsuaio
{
    public class CUEditarUsuario : ICUEditarUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IRepositorioAuditoria _repositorioAuditoria;

        public CUEditarUsuario(IRepositorioUsuario repositorioUsuario, IRepositorioAuditoria repositorioAuditoria)
        {
            _repositorioUsuario = repositorioUsuario;
            _repositorioAuditoria = repositorioAuditoria;
        }

        public void Ejecutar(DTOEditarUsuarioRequest dto)
        {
            Usuario antiguo = _repositorioUsuario.findById(dto.Id);

            if (antiguo is null)
                throw new Exception("El usuario no existe");

            Usuario nuevo = UsuarioMapper.ToUsuarioEdit(dto, antiguo);
            int nuevoId = _repositorioUsuario.Update(nuevo);

            Auditoria auditoria = new Auditoria("Edit", JsonSerializer.Serialize(antiguo) + "/" + JsonSerializer.Serialize(nuevo), dto.loguadoId, "Usuario", nuevoId);
            _repositorioAuditoria.Add(auditoria);
        }
    }
}
