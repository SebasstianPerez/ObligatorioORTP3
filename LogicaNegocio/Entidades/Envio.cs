using LogicaNegocio.CustomExceptions;
using LogicaNegocio.CustomExceptions.UsuarioException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public abstract class Envio 
    {
        public int Id { get; set; }
        public string? NumeroTracking { get; set; }
        public Usuario Empleado { get; set; }
        public int EmpleadoId { get; set; }
        public Usuario Cliente { get; set; }
        public int ClienteId { get; set; }
        public Double Peso { get; set; }
        public Estado Estado { get; set; }
        public int? AgenciaId { get; set; }

        public List<Seguimiento> Seguimiento { get; set; }
        public string TipoEnvio { get; set; }

        public Envio(Usuario empleado, Usuario cliente,double peso, string tipoEnvio)
        {
            Empleado = empleado;
            Cliente = cliente;
            Peso = peso;
            Estado = global::Estado.EN_PROCESO;
            TipoEnvio = tipoEnvio;
            Seguimiento = new List<Seguimiento>();
            agregarSeguimiento("Ingresado en agencia de origen", null);
        }

        public Envio()
        {
            Seguimiento = new List<Seguimiento>();
            Estado = Estado.EN_PROCESO;
        }

        public string GenerarNumeroTracking()
        {
            Guid guid = Guid.NewGuid();
            string tracking = guid.ToString();
            tracking += DateTime.Now.ToString("ddMM");
            return tracking;
        }

        public virtual void FinalizarEnvio(int idEmpleado)
        {
            //Correccion de finalizar envio con polimorfismo
            Estado = Estado.FINALIZADO;
            
            agregarSeguimiento("Envio Finalizado", idEmpleado);
        }

        public void agregarSeguimiento(string comentario, int? idEmpleado)
        {
            if (string.IsNullOrWhiteSpace(comentario))
                throw new ArgumentNullException("Comentario no puede ser nulo");

            if (idEmpleado == null)
                throw new ArgumentNullException("No hay empleado asignado para seguimiento");
            

            this.Seguimiento.Add(new Seguimiento(comentario, (int)idEmpleado, this));
        }


        public void Validar()
        {
            if (Empleado == null)
                throw new ArgumentNullException(nameof(Empleado), "Empleado no puede ser nulo.");

            if (Empleado.Rol != "Empleado" && Empleado.Rol != "Admin")
                throw new UsuarioNoAutorizadoException("El usuario asignado debe tener rol 'Empleado' o 'Admin'.");

            if (Cliente == null)
                throw new ArgumentNullException(nameof(Cliente), "Cliente no puede ser nulo.");

            if (Cliente.Rol != "Cliente")
                throw new UsuarioNoAutorizadoException("El destinatario debe tener rol 'Cliente'.");

            if (Peso <= 0)
                throw new ArgumentException("El peso debe ser mayor a 0.", nameof(Peso));

            if (string.IsNullOrWhiteSpace(TipoEnvio))
                throw new ArgumentException("El tipo de envío no puede estar vacío.", nameof(TipoEnvio));
        }
    }
}
