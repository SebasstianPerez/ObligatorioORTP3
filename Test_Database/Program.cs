using LogicaAccesoDatos;
using LogicaNegocio.Entidades;
using LogicaNegocio.VO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Obligatorio;Trusted_Connection=True;TrustServerCertificate=True"))
                .BuildServiceProvider();

        using (var _context = serviceProvider.GetRequiredService<ApplicationDbContext>())
        {
            
            /////Usuarios
            
            //Usuario u = new();
            //u.NombreCompleto = new NombreCompleto("Juan", "Pérez");
            //u.Email = "juan@gmail.com";
            //u.Contrasena = "1234";
            //u.Rol = "Empleado";

            //_context.Usuarios.Add(u);
            //_context.SaveChanges();


            Usuario admin = new();
            admin.NombreCompleto = new NombreCompleto("Admin", "Admin");
            admin.Email = "admin";
            admin.Contrasena = "admin";
            admin.Rol = "Admin";

            _context.Usuarios.Add(admin);
            _context.SaveChanges();


            //////Agencia
            
            //Agencia agencia = new();
            //agencia.Nombre = "Agencia 1";
            //agencia.DireccionPostal = new DireccionPostal("Calle 1", "1", "Ciudad 1", "12345");
            //agencia.Telefono = "123456789";
            //agencia.Latitud = "12.345678";
            //agencia.Longitud = "98.765432";

            //_context.Agencias.Add(agencia);
            //_context.SaveChanges();


            //////Envio


            //object usuario = _context.Usuarios.FirstOrDefault(p => p.Email.Equals("juan@gmail.com"));

            //Urgente envio = new();
            //DireccionPostal direccion = new DireccionPostal("Calle 1", "1", "Ciudad 1", "12345");

            //envio.NumeroTracking = "123456789";
            //envio.Empleado = (Usuario)usuario;
            //envio.Cliente = (Usuario)usuario;
            //envio.Peso = 10.5;
            //envio.TipoEnvio = "Urgente";
            //envio.DireccionPostal = direccion;

            //_context.Envios.Add(envio);
            //_context.SaveChanges();



            //////Seguimiento

            //var urgente = _context.Envios.OfType<Urgente>()
            //    .FirstOrDefault(p => p.NumeroTracking == "123456789");

            //List<Urgente> urgentes = new();

            //urgentes = _context.Envios.OfType<Urgente>().ToList();
            //System.Console.WriteLine(urgentes.FirstOrDefault());

            //var empleado = _context.Usuarios.FirstOrDefault(p => p.Email.Equals("juan@gmail.com"));

            //if (urgentes is null)
            //{
            //    throw new Exception("No se encontro el envio");
            //}

            //if (empleado is null)
            //{
            //    throw new Exception("No se encontró el empleado.");
            //}

            //Seguimiento seguimiento = new();
            //seguimiento.EnvioId = (int)urgente.Id;
            //seguimiento.Fecha = DateTime.Now;
            //seguimiento.Comentario = "Enviado desde la agencia 1";
            //seguimiento.EmpleadoId = (int)empleado.Id;

            //_context.Seguimientos.Add(seguimiento);
            //_context.SaveChanges();

            
        }
    }
}