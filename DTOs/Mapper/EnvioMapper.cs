using DTOs.DTOs.Envio;
using LogicaNegocio.Entidades;
using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Mapper
{
    public class EnvioMapper
    {
        public static DTOEnvio ToDTOEnvio(Envio envio)
        {
            DTOEnvio ret = new DTOEnvio();

            ret.Id = envio.Id;
            ret.Estado = envio.Estado.ToString();
            ret.NumeroTracking = envio.NumeroTracking;
            ret.ClienteEmail = UsuarioMapper.ToDTOUsuario(envio.Cliente).Email;
            ret.EmpleadoId = envio.Empleado.Id;
            ret.Tipo = envio.GetType().Name;
            ret.Peso = envio.Peso;
            ret.Seguimientos = ToListDtoSeguimiento(envio.Seguimiento).ToList();

            if (envio is Comun comun)
            {
                ret.AgenciaId = comun.AgenciaId;
            }
            else if (envio is Urgente urgente)
            {
                ret.DireccionPostal = urgente.DireccionPostal;
            }

            return ret;            
        }

        public static List<DTOSeguimiento> ToListDtoSeguimiento(List<Seguimiento> seguimientos)
        {
            List<DTOSeguimiento> ret = new List<DTOSeguimiento>();

            foreach (var s in seguimientos)
            {
                DTOSeguimiento dto = new DTOSeguimiento();
                dto.Comentario = s.Comentario;
                dto.Fecha = s.Fecha;
                dto.IdEmpleado = s.Empleado.Id;

                ret.Add(dto);
            }

            return ret;
        }

        public static Envio ToEnvio(DTOEnvio dto, Usuario cliente, Usuario empleado)
        {
            Envio envio;

            if (dto.Tipo == "Urgente")
            {
                envio = new Urgente();
            }
            else if (dto.Tipo == "Comun")
            {
                envio = new Comun();
            } 
            else
            {
                throw new Exception("Envio tipo invalido");
            }

            envio.Cliente = cliente;
            envio.Empleado = empleado;
            envio.NumeroTracking = envio.GenerarNumeroTracking();
            envio.Peso = dto.Peso;
            envio.Estado = global::Estado.EN_PROCESO;
            envio.TipoEnvio = dto.Tipo;

            if(envio is Urgente urgente)
            {
                urgente.DireccionPostal = dto.DireccionPostal;
            }

            return envio;
        }

        public static List<DTOEnvio> ToListDTOEnvio(List<Envio> envios)
        {
            List<DTOEnvio> dto = new List<DTOEnvio>();

            foreach (var env in envios)
            {
                DTOEnvio dtoEnvio = ToDTOEnvio(env);
                
                dto.Add(dtoEnvio);
            }
            return dto;
        }
    } 
}
