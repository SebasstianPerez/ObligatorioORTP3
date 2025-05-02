using DTOs.DTOs;
using DTOs.DTOs.Usuario;
using LogicaAplicacion.ICasosUso.ICUUsuario;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Mapper
{
    public class UsuarioMapper
    {
        public static DTOUsuario ToDTOUsuario(Usuario u)
        {
            DTOUsuario dto = new DTOUsuario();
            dto.Id = u.Id;
            dto.Nombre = u.NombreCompleto.Nombre;
            dto.Apellido = u.NombreCompleto.Apellido;
            dto.Email = u.Email;
            dto.Rol = u.Rol;

            return dto;
        }

        public static List<DTOUsuario> ToListDTOUsuario(List<Usuario> usuarios)
        {
            List<DTOUsuario> ret = new List<DTOUsuario>();

            foreach (var item in usuarios)
            {
                DTOUsuario dto = new DTOUsuario();

                dto.Id = item.Id;
                dto.Nombre = item.NombreCompleto.Nombre;
                dto.Apellido = item.NombreCompleto.Apellido;
                dto.Email = item.Email;
                dto.Rol = item.Rol;

                ret.Add(dto);
            }

            return ret;
        }

        public static Usuario ToUsuario(DTOCreateRequest dto)
        {
            string passHashed = Utilities.Crypto.HashPasswordConBcrypt(dto.Contrasena, 12);
            Usuario ret = new(new LogicaNegocio.VO.NombreCompleto(dto.Nombre, dto.Apellido), dto.Email, passHashed);
            return ret;
        }

        public static Usuario ToUsuarioEdit(DTOEditarUsuarioRequest dto, Usuario antiguo)
        {
            antiguo.NombreCompleto = new LogicaNegocio.VO.NombreCompleto(dto.Nombre, dto.Apellido);
            antiguo.Email = dto.Email;
            antiguo.Rol = dto.Rol;
            
          
            return antiguo;
        }
     }
}
 