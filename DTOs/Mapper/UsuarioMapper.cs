using DTOs.DTOs;
using DTOs.DTOs.Usuario;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Mapper
{
    public class UsuarioMapper
    {
        public static List<DTOListUsuarios> ToListDTOUsuario(List<Usuario> usuarios)
        {
            List<DTOListUsuarios> ret = new List<DTOListUsuarios>();

            foreach (var item in usuarios)
            {
                DTOListUsuarios dto = new DTOListUsuarios();
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
            //TODO PassHash with BCRYPT

            
            Usuario ret = new(new LogicaNegocio.VO.NombreCompleto(dto.Nombre, dto.Apellido), dto.Email, dto.Contrasena);
            return ret;
        }
     }
}
