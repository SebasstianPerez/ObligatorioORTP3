
using LogicaAccesoDatos;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.CasosUso.CUEnvio;
using LogicaAplicacion.ICasosUso.ICUEnvio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ClientAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //JWT
            //La clave debe ser almacenada en el json, o en el sistema operativo cuando esté
            //en producción. PONER EN APPSETTINGS
            string clave = builder.Configuration.GetValue<String>("ClaveToken");
            
            var claveCodificada = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(clave));

             builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(opt =>
             {
	             opt.TokenValidationParameters = new TokenValidationParameters 
	             {
		             ValidateIssuer = false,
		             ValidateAudience = false,
		             ValidateLifetime = true,
		             ValidateIssuerSigningKey = true,
		             IssuerSigningKey = claveCodificada
	             };
             });

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            // Add services to the container.
            builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();

            builder.Services.AddScoped<ICUGetEnvioTracking, CUGetEnvioTracking>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
