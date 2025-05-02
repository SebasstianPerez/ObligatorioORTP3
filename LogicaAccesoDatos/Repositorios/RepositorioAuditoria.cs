using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioAuditoria : IRepositorioAuditoria
    {

        private ApplicationDbContext _context;

        public RepositorioAuditoria(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Auditoria aud)
        {
            _context.Auditorias.Add(aud);
            _context.SaveChanges();
        }
    }
}
