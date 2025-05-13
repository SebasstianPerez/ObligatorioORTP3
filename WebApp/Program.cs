using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUEnvio;
using LogicaAplicacion.ICasosUso.ICUEnvio;
using LogicaAccesoDatos;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;
using LogicaAplicacion.ICasosUso.ICUUsuario;
using LogicaAplicacion.CasosUso.CUUsuaio;
using LogicaAplicacion.CasosUso.CUUsuario;
using LogicaAplicacion.ICasosUso.ICUAuditoria;
using LogicaAplicacion.CasosUso.CUAuditoria;
using LogicaAplicacion.CasosUso.CUAgencia;
using LogicaAplicacion.ICasosUso.ICUAgencia;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            var connectionString =
                builder.Configuration.GetConnectionString("DefaultConnection");
           

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(connectionString));

            builder.Services.AddControllersWithViews();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();
            builder.Services.AddScoped<IRepositorioAgencia, RepositorioAgencia>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioSeguimiento, RepositorioSeguimiento>();
            builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();

            builder.Services.AddScoped<ICUAltaEnvio, CUAltaEnvio>();
            builder.Services.AddScoped<ICUGetEnvio, CUGetEnvio>();
            builder.Services.AddScoped<ICUGetEnvios, CUGetEnvios>();
            builder.Services.AddScoped<ICUGetEnviosEnProceso, CUGetEnviosEnProceso>();
            builder.Services.AddScoped<ICUFinalizarEnvio, CUFinalizarEnvio>();

            builder.Services.AddScoped<ICUGetAgencias, CUGetAgencias>();

            builder.Services.AddScoped<ICUAltaUsuario, CUAltaUsuario>();
            builder.Services.AddScoped<ICUEditarUsuario, CUEditarUsuario>();
            builder.Services.AddScoped<ICULogin, CULogin>();
            builder.Services.AddScoped<ICUGetUsuarios, CUGetUsuarios>();
            builder.Services.AddScoped<ICUGetDatosUsuario, CUGetDatosUsuario>();
            builder.Services.AddScoped<ICUBajaUsuario, CUBajaUsuario>();
            builder.Services.AddScoped<ICUAuditar, CUAuditar>();

            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
