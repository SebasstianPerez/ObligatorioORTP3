using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioAgencia : IRepositorioAgencia
    {
        private ApplicationDbContext _context;

        public RepositorioAgencia(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Agencia item)
        {
            _context.Agencias.Add(item);
            _context.SaveChanges();
            return item.Id;
        }

        public void Delete(Agencia item)
        {
            throw new NotImplementedException();
        }

        public List<Agencia> findAll()
        {
            throw new NotImplementedException();
        }

        public Agencia findById(int id)
        {
            Agencia ret = new Agencia();
            ret = _context.Agencias.FirstOrDefault(a => a.Id == id);
            return ret;
        }

        public Agencia findByNombre(string nombre)
        {
            Agencia agencia = _context.Agencias.FirstOrDefault(a => a.Nombre == nombre);
            return agencia;
        }

        public List<Agencia> GetAll()
        {
            List<Agencia> ret = new List<Agencia>();
            ret = _context.Agencias.ToList();
            return ret;
        }

        public int Update(Agencia item)
        {
            throw new NotImplementedException();
        }
    }
}
