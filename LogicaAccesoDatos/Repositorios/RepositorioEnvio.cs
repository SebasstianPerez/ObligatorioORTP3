using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioEnvio : IRepositorioEnvio
    {
        private ApplicationDbContext _context;

        public RepositorioEnvio(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Envio item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item.Id;
        }

        public void Delete(Envio item)
        {
            _context.Envios.Remove(item);
            _context.SaveChanges();
        }

        public Envio findById(int id)
        {
            Envio envio = _context.Envios
                .Include(e => e.Cliente)
                .Include(e => e.Empleado)
                .Include(e => e.Seguimiento)
                .FirstOrDefault(p => p.Id == id);

            if (envio is Comun comun)
            {
                _context.Entry(comun).Reference(e => e.agencia).Load();
            }

            return envio;
        }

        public Envio findByNroTracking(string nroTracking)
        {
            if (string.IsNullOrEmpty(nroTracking) || nroTracking.Length > 8)
                return null;

            Envio envio = _context.Envios
                .Include(e => e.Cliente)
                .Include(e => e.Empleado)
                .Include(e => e.Seguimiento)
                .Where(e => e.Estado == Estado.EN_PROCESO)
                .FirstOrDefault(p =>
                    p.NumeroTracking != null &&
                    p.NumeroTracking.EndsWith(nroTracking)
                );

            if (envio is Comun comun)
            {
                _context.Entry(comun).Reference(e => e.agencia).Load();
            }

            return envio;
        }


        public List<Envio> GetAll()
        {
            List<Envio> ret = new List<Envio>();
            ret = _context.Envios
                .Include(e => e.Cliente)
                .Include(e => e.Empleado)
                .Include(e => e.Seguimiento)
                .ToList();
            return ret;
        }

        public List<Envio> GetEnviosEnProceso()
        {
            List<Envio> ret = new List<Envio> ();
            ret = _context.Envios
                .Include(e => e.Cliente)
                .Include(e => e.Empleado)
                .Where(e => e.Estado == Estado.EN_PROCESO)
                .ToList();
            return ret;
        }

        public List<Seguimiento> GetSeguimientos()
        {
            throw new NotImplementedException();
        }

        public int Update(Envio item)
        {
            _context.Update(item);
            _context.SaveChanges();
            return item.Id;
        }
    }
}
