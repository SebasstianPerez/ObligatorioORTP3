using DTOs.DTOs.Agencia;
using LogicaNegocio.Entidades;
using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DTOs.Mapper
{
    public class AgenciaMapper
    {
        public static List<DTOAgencia> ToListDTOAgencia(List<Agencia> agencias)
        {
            List<DTOAgencia> ret = new List<DTOAgencia>();

            foreach (Agencia a in agencias)
            {
                ret.Add(ToDTOAgencia(a));
            }

            return ret;
        }

        public static DTOAgencia ToDTOAgencia(Agencia a)
        {
            DTOAgencia ret = new DTOAgencia();

            ret.Id = a.Id;
            ret.Nombre = a.Nombre;
            ret.Telefono = a.Telefono;
            ret.DireccionPostal = a.DireccionPostal;
            ret.Latitud = a.Latitud;
            ret.Longitud = a.Longitud;

            return ret;
        }
    }
}