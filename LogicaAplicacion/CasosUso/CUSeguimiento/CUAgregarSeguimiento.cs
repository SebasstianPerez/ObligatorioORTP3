using LogicaAplicacion.ICasosUso.ICUSeguimiento;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUSeguimiento
{
    public class CUAgregarSeguimiento : ICUAgregarSeguimiento
    {
        private readonly IRepositorioSeguimiento _repositorioSeguimiento;
        private readonly IRepositorioEnvio _repositorioEnvio;

        public void Ejecutar(int idEnvio, int idEmpleado, string comentario)
        {
            Envio envio = _repositorioEnvio.findById(idEnvio);
            if (envio == null) {
                throw new Exception("El envio no existe");
            }
            
            Usuario empleado = envio.Empleado;
            if (empleado == null) {
                throw new Exception("El empleado no existe");
            }

            _repositorioSeguimiento.Add(new Seguimiento(comentario, empleado, envio));


        }
    }
}
