using DTOs.DTOs.Envio;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.ICasosUso.ICUEnvio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUGetEnvios : ICUGetEnvios
    {

        private readonly RepositorioEnvio _repositorioEnvio;

        public CUGetEnvios(RepositorioEnvio repositorioEnvio)
        {
            _repositorioEnvio = repositorioEnvio;
        }

        public List<DTOGetAllEnvios> Ejecutar()
        {
            List<DTOGetAllEnvios> Envios = new List<DTOGetAllEnvios>();
            var envios = _repositorioEnvio.GetAll();
            foreach (var env in envios)
            {
                Envios.Add(new DTOGetAllEnvios()
                {
                    Id = env.Id,
                    Destinatario = env.Destinatario,
                    Direccion = env.Direccion,
                    Telefono = env.Telefono,
                    FechaEnvio = env.FechaEnvio,
                    Estado = env.Estado
                });
            }
        }
    }
}
