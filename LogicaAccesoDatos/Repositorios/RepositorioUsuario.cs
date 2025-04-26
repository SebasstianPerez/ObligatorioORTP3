using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private ApplicationDbContext _context;

        public RepositorioUsuario(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Usuario item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Usuario item)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> findAll()
        {
            throw new NotImplementedException();
        }

        public Usuario FindByEmail(string email)
        {
            Usuario u = _context.Usuarios.FirstOrDefault(p => p.Email == email);
            return u;
        }

        public Usuario findById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Usuario item)
        {
            throw new NotImplementedException();
        }
    }
}
