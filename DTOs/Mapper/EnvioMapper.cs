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
        public static DTOGetEnvios ToDTOEnvio(Envio envio)
        {
            DTOGetEnvios ret = new DTOGetEnvios();

            ret.Estado = envio.Estado;

            //TODO castear Estado a String
        }

        public static Envio ToEnvio(DTOAltaEnvioRequest dto, Usuario cliente, Usuario empleadoId)
        {
            Envio envio;
            if (dto.TipoEnvio == "Urgente")
            {
                envio = new Urgente();
            }
            else if (dto.TipoEnvio == "Comun")
            {
                envio = new Comun();
            } 
            else
            {
                throw new Exception("Envio tipo invalido");
            }

            envio.Cliente = cliente;
            envio.Empleado = empleadoId;
            envio.GenerarNumeroTracking();
            envio.Peso = dto.Peso;
            envio.Estado = global::Estado.EN_PROCESO;

            if(envio is Urgente urgente)
            {
                urgente.DireccionPostal = dto.DireccionPostal;
            } 

            return envio;

        }

        public static List<DTOGetEnvios> ToListDTOEnvio(List<Envio> envios)
        {
            List<DTOGetEnvios> dto = new List<DTOGetEnvios>();

            foreach (var env in envios)
            {
                string estado = env.Estado.ToString("D");

                dto.Add(
                    new DTOGetEnvios(

                        env.TipoEnvio,
                        env.NumeroTracking,
                        env.Cliente.Email,
                        env.Peso,
                        estado
                    ));
            }
            return dto;
        }
    } 
}
