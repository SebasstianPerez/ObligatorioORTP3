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
    
    } 
}
