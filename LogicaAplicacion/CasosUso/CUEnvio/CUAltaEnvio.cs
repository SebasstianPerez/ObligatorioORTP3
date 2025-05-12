using DTOs.DTOs.Envio;
using DTOs.Mapper;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.ICasosUso.ICUEnvio;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUAltaEnvio : ICUAltaEnvio
    {
        private readonly RepositorioEnvio _repositorioEnvio;
        private readonly RepositorioUsuario _repositorioUsuario;
        private readonly RepositorioAgencia _repositorioAgencia;

        public void Ejecutar(DTOAltaEnvioRequest dto)
        {
            try{
                Usuario cliente = _repositorioUsuario.FindByEmail(dto.EmailCliente);
                Usuario empleado = _repositorioUsuario.findById(dto.LogueadoId);

                Envio envio = EnvioMapper.ToEnvio(dto, cliente, empleado);

                if (envio is Comun comun)
                {
                    Agencia agencia = _repositorioAgencia.findByNombre(dto.AgenciaDestino);
                    comun.agencia = agencia;
                }

                _repositorioEnvio.Add(envio);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
