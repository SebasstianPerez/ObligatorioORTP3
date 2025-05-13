using DTOs.DTOs.Agencia;
using DTOs.Mapper;
using LogicaAplicacion.ICasosUso.ICUAgencia;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUAgencia
{
    public class CUGetAgencias : ICUGetAgencias
    {
        private readonly IRepositorioAgencia _repositorioAgencia;

        public CUGetAgencias(IRepositorioAgencia repositorioAgencia)
        {
            _repositorioAgencia = repositorioAgencia;
        }

        public List<DTOAgencia> Ejecutar()
        {
            List<DTOAgencia> ret = new List<DTOAgencia>();

            ret = AgenciaMapper.ToListDTOAgencia(_repositorioAgencia.GetAll());

            return ret;
        }
    }
}
