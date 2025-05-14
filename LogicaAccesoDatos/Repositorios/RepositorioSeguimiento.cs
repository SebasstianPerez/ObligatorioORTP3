using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioSeguimiento : IRepositorioSeguimiento
    {
        private ApplicationDbContext _context;

        public RepositorioSeguimiento(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Seguimiento item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item.Id;
        }

        public void Delete(Seguimiento item)
        {
            throw new NotImplementedException();
        }

        public List<Seguimiento> findAll()
        {
            throw new NotImplementedException();
        }

        public Seguimiento findById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Seguimiento> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Update(Seguimiento item)
        {
            throw new NotImplementedException();
        }
    }
}
