using LogicaAccesoDatos;
using LogicaNegocio.Entidades;
using LogicaNegocio.VO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Utilities;

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

            //Usuarios

            var usuarios = new List<Usuario>();

            // Cliente
            var cliente = new Usuario
            {
                NombreCompleto = new NombreCompleto("Cliente", "Ejemplo"),
                Email = "cliente@example.com",
                Contrasena = Crypto.HashPasswordConBcrypt("cliente123", 12),
                Rol = "Cliente"
            };
            usuarios.Add(cliente);

            // Empleados
            for (int i = 1; i <= 9; i++)
            {
                var empleado = new Usuario
                {
                    NombreCompleto = new NombreCompleto($"Empleado{i}", "Ejemplo"),
                    Email = $"empleado{i}@example.com",
                    Contrasena = Crypto.HashPasswordConBcrypt($"empleado{i}123", 12),
                    Rol = "Empleado"
                };
                usuarios.Add(empleado);
            }

            Usuario u = new();
            u.NombreCompleto = new NombreCompleto("Juan", "Pérez");
            u.Email = "juan@gmail.com";
            u.Contrasena = Crypto.HashPasswordConBcrypt(u.Contrasena = "1234", 12);
            u.Rol = "Empleado";

            usuarios.Add(u);
             


            Usuario u1 = new();
            u1.NombreCompleto = new NombreCompleto("Mario", "Pérez");
            u1.Email = "mario@gmail.com";
            u1.Contrasena = Crypto.HashPasswordConBcrypt(u1.Contrasena = "mario1234", 12);
            u1.Rol = "Cliente";

            usuarios.Add(u1);

            
             Usuario admin = new();
            admin.NombreCompleto = new NombreCompleto("Admin", "Admin");
            admin.Email = "admin";
            admin.Contrasena = Crypto.HashPasswordConBcrypt(admin.Contrasena = "admin", 12);
            admin.Rol = "Admin";

            usuarios.Add(admin);
             
            _context.Usuarios.AddRange(usuarios);
            _context.SaveChanges();


            //Agencias

            var agencias = new List<Agencia>();

            for (int i = 1; i <= 10; i++)
            {
                var agencia = new Agencia
                {
                    Nombre = $"Agencia{i}",
                    DireccionPostal = $"12{i:0000}",  
                    Telefono = $"12345678{i}",             
                    Latitud = (12.3 + i * 0.01).ToString("F6"),
                    Longitud = (98.7 - i * 0.01).ToString("F6")
                };
                agencias.Add(agencia);
            }

            _context.Agencias.AddRange(agencias);
            _context.SaveChanges();



            //////Envio

            var empleados = _context.Usuarios.Where(u => u.Rol == "Empleado").Take(5).ToList();

            if (cliente == null || empleados.Count == 0)
                throw new Exception("No hay usuarios suficientes para asignar envíos.");

            var direccionesPostales = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                direccionesPostales.Add((10000 + i).ToString()); // Ej: "10000", "10001", ..., "10009"
            }

            var envios = new List<Envio>();

            List<Agencia> a = _context.Agencias.ToList();

            //Envios Comunes
            for (int i = 0; i < 5; i++)
            {
                var envioComun = new Comun
                {
                    Empleado = empleados[i % empleados.Count],
                    Cliente = cliente,
                    Peso = Math.Round(1 + i * 0.5),
                    TipoEnvio = "Comun",
                    agencia = a[i]
                };

                envioComun.agregarSeguimiento("Ingresado en agencia de origen", envioComun.Empleado.Id);
                envioComun.NumeroTracking = envioComun.GenerarNumeroTracking();

                envios.Add(envioComun);
            }

            // Envios urgentes
            for (int i = 0; i < 5; i++)
            {
                var envioUrgente = new Urgente
                {
                    Empleado = empleados[i],
                    Cliente = cliente,
                    Peso = Math.Round(1 + i * 0.7),
                    TipoEnvio = "Urgente",
                    DireccionPostal = direccionesPostales[i],
                };

                envioUrgente.agregarSeguimiento("Ingresado en agencia de origen", envioUrgente.Empleado.Id);
                envioUrgente.NumeroTracking = envioUrgente.GenerarNumeroTracking();

                envios.Add(envioUrgente);
            }

            _context.Envios.AddRange(envios);
            _context.SaveChanges();
        }
    }
}