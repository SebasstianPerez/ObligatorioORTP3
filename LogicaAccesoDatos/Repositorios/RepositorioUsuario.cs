using LogicaNegocio.CustomExceptions;
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
            _context.Usuarios.Add(item);
            _context.SaveChanges();
            return item.Id;
        }

        public void Delete(Usuario item)
        {
            Usuario u = _context.Usuarios.FirstOrDefault(p => p.Id == item.Id);
            u.Activo = false;
            _context.SaveChanges();
        }

        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = 
                _context.Usuarios
                .Where(p => p.Activo == true)
                .ToList();
            return usuarios;
        }

        public Usuario FindByEmail(string email)
        {
            Usuario u = 
                _context.Usuarios
                .FirstOrDefault(p => p.Email == email);
            return u;
        }

        public Usuario findById(int id)
        {
            Usuario u = 
                _context.Usuarios
                .Where(p => p.Activo == true)
                .FirstOrDefault(p => p.Id == id);
            return u;
        }

        public int Update(Usuario item)
        {
            _context.SaveChanges();
             return item.Id;
        }
    }
}
