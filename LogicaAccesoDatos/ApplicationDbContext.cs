using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Comun> Comunes { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Seguimiento> Seguimientos { get; set; }
        public DbSet<Urgente> Urgentes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Agencia>()
                .OwnsOne(a => a.DireccionPostal, n =>
                    {
                        n.Property(p => p.NumCalle).HasColumnName("NumeroPuerta");
                        n.Property(p => p.Calle).HasColumnName("Calle");
                        n.Property(p => p.Ciudad).HasColumnName("Ciudad");
                        n.Property(p => p.CodigoPostal).HasColumnName("CodigoPostal");
            
                    }
           );

            modelBuilder.Entity<Usuario>()
                .OwnsOne(a => a.NombreCompleto, n =>
                {
                    n.Property(p => p.Nombre).HasColumnName("Nombre");
                    n.Property(p => p.Apellido).HasColumnName("Apellido");
                });

            modelBuilder.Entity<Envio>()
                .HasDiscriminator<string>("TipoEnvio")
                .HasValue<Comun>("EnvioComun")
                .HasValue<Urgente>("EnvioUrgente");
            
            modelBuilder.Entity<Envio>()
                .HasMany(e => e.Seguimiento)
                .WithOne(s => s.Envio)
                .HasForeignKey(s => s.EnvioId);

            modelBuilder.Entity<Seguimiento>()
                .HasOne(s => s.Empleado)
                .WithMany()
                .HasForeignKey(s => s.EmpleadoId);

            modelBuilder.Entity<Usuario>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Seguimiento>()
                .HasOne(u => u.Empleado)
                .WithMany();
        }
    }
}
