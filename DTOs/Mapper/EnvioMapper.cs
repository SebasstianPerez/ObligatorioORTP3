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

            ret.Estado = envio.Estado.ToString();
            ret.NumeroTracking = envio.NumeroTracking;
            ret.ClienteEmail = UsuarioMapper.ToDTOUsuario(envio.Cliente).Email;
            ret.EmpleadoId = envio.Empleado.Id;
            ret.Peso = envio.Peso;

            if (envio is Comun comun)
            {
                ret.AgenciaNombre = comun.agencia.Nombre;
            }
            else if (envio is Urgente urgente)
            {
                ret.DireccionPostal = urgente.DireccionPostal;
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
