using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorio<T> where T : class
    {
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        T findById(int id);
        List<T> findAll();
    }
}
