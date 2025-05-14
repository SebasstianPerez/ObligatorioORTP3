using DTOs.DTOs.Envio;
using DTOs.Mapper;
using LogicaAplicacion.CasosUso.CUSeguimiento;
using LogicaAplicacion.ICasosUso.ICUEnvio;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUAltaEnvio : ICUAltaEnvio
    {
        private readonly IRepositorioEnvio _repositorioEnvio;
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IRepositorioAgencia _repositorioAgencia;

        public CUAltaEnvio(IRepositorioEnvio repositorioEnvio, IRepositorioUsuario repositorioUsuario, IRepositorioAgencia repositorioAgencia)
        {
            _repositorioEnvio = repositorioEnvio;
            _repositorioUsuario = repositorioUsuario;
            _repositorioAgencia = repositorioAgencia;
        }

        public void Ejecutar(DTOEnvio dto)
        {
            try{
                Usuario cliente = _repositorioUsuario.FindByEmail(dto.ClienteEmail);

                if(cliente == null)
                    throw new Exception("El cliente no existe");
                
                Usuario empleado = _repositorioUsuario.findById(dto.EmpleadoId);

                if (empleado == null)
                    throw new Exception("El empleado no existe");

                Envio envio = EnvioMapper.ToEnvio(dto, cliente, empleado);

                if (envio is Comun comun)
                {
                    Agencia agencia = _repositorioAgencia.findById((int)dto.AgenciaId);
                    comun.agencia = agencia;
                    comun.AgenciaId = agencia.Id;
                }
                envio.agregarSeguimiento("Ingresado en agencia de origen");
                _repositorioEnvio.Add(envio);
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
