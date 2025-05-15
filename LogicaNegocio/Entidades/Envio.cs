using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Envio
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

        public Envio(Usuario empleado, Usuario cliente,double peso, List<Seguimiento> seguimiento, string tipoEnvio)
        {
            Empleado = empleado;
            Cliente = cliente;
            Peso = peso;
            Estado = global::Estado.EN_PROCESO;
            Seguimiento = seguimiento;
            TipoEnvio = tipoEnvio;
            Seguimiento = new List<Seguimiento>();
            agregarSeguimiento("Ingresado en agencia de origen");
        }

        public Envio()
        {
            Seguimiento = new List<Seguimiento>();
        }

        public string GenerarNumeroTracking()
        {
            Guid guid = Guid.NewGuid();
            string tracking = guid.ToString();
            tracking += DateTime.Now.ToString("ddMM");
            return tracking;
        }

        public virtual void FinalizarEnvio()
        {
            //Correccion de finalizar envio con polimorfismo
            Estado = global::Estado.FINALIZADO;
            
            agregarSeguimiento("Envio Finalizado");
        }

        public void agregarSeguimiento(string comentario)
        {
            if (comentario is null)
            {
                throw new Exception("Comentario invalido");
            }

            this.Seguimiento.Add(new Seguimiento(comentario, Empleado, this));
        }

        public void Validar()
        {
            if (Empleado == null) throw new ArgumentNullException(nameof(Empleado), "Empleado no puede ser nulo.");
            if (Empleado.Rol != "Empleado" && Empleado.Rol != "Admin")
                throw new Exception("El usuario asignado debe tener rol 'Empleado' o 'Admin'.");

            if (Cliente == null) throw new ArgumentNullException(nameof(Cliente), "Cliente no puede ser nulo.");
            if (Cliente.Rol != "Cliente") throw new Exception("El destinatario debe ser un cliente.");

            if (Peso <= 0) throw new Exception("El peso debe ser mayor a 0.");

            if (string.IsNullOrWhiteSpace(TipoEnvio)) throw new Exception("El tipo de envío no puede estar vacío.");
        }
    }
}
