using DTOs.DTOs.Envio;
using DTOs.Mapper;
using LogicaAplicacion.ICasosUso.ICUEnvio;
using LogicaNegocio.CustomExceptions.Envio;
using LogicaNegocio.CustomExceptions.Usuario;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUGetEnviosPorComentario : ICUGetEnviosPorComentario
    {
        private readonly IRepositorioEnvio _repoEnvio;

        public CUGetEnviosPorComentario(IRepositorioEnvio repoEnvio)
        {
            _repoEnvio = repoEnvio;
        }
        public List<DTOEnvio> Ejecutar(string email, string comentario)
        {
            List<DTOEnvio> ret = new List<DTOEnvio>();

            ret = EnvioMapper.ToListDTOEnvio(_repoEnvio.GetEnviosClientePorComentario(email, comentario));

            if (email.IsNullOrEmpty())
                throw new UsuarioNoEncontradoException("El email proporcionado no es válido o no existe.");

            if (comentario.IsNullOrEmpty())
                throw new ArgumentException("Comentario invalido.");

            if (ret.IsNullOrEmpty())
                throw new EnvioNoExisteException("No existe envios con ese comentario.");

            return ret;
        }
    }
}
