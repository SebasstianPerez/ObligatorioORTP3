using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
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
            Envio envio = _context.Envios.FirstOrDefault(p => p.Id == id);
            return envio;
        }

        public List<Envio> GetAll()
        {
            List<Envio> ret = new List<Envio>();
            ret = _context.Envios.ToList();
            return ret;
        }

        public List<Seguimiento> GetSeguimientos()
        {
            throw new NotImplementedException();
        }

        public int Update(Envio item)
        {
            throw new NotImplementedException();
        }
    }
}
