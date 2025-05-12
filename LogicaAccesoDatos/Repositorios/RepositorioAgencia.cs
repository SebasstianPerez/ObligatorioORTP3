using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
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
            throw new NotImplementedException();
        }

        public Agencia findByNombre(string nombre)
        {
            Agencia agencia = _context.Agencias.FirstOrDefault(a => a.Nombre == nombre);
            return agencia;
        }

        public List<Agencia> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Update(Agencia item)
        {
            throw new NotImplementedException();
        }
    }
}
