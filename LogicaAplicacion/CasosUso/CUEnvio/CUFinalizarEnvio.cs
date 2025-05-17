using DTOs.DTOs.Envio;
using LogicaAplicacion.CasosUso.CUSeguimiento;
using LogicaAplicacion.ICasosUso.ICUEnvio;
using LogicaAplicacion.ICasosUso.ICUSeguimiento;
using LogicaNegocio.CustomExceptions.Envio;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUFinalizarEnvio : ICUFinalizarEnvio
    {
        private readonly IRepositorioEnvio _repositorioEnvio;

        public CUFinalizarEnvio(IRepositorioEnvio repositorioEnvio)
        {
            _repositorioEnvio = repositorioEnvio;
        }

        public void Ejecutar(DTOFinalizarEnvio dto)
        {
            try
            {
                Envio envio = _repositorioEnvio.findById(dto.EnvioId);

                if (envio == null)
                    throw new EnvioNoExisteException("El envio no existe");

                if (envio.Estado == Estado.FINALIZADO)
                    throw new EnvioFinalizadoException("El envio ya esta FINALIZADO");

                else
                {
                    envio.FinalizarEnvio(dto.LogueadoId);
                    _repositorioEnvio.Update(envio);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
