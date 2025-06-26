using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Core
{
    public class PaginacionResultado<T>
    {
        
        public List<T> Items { get; set; } = new List<T>();
        public int TotalItems { get; set; }

        public PaginacionResultado()
        {

        }

        public PaginacionResultado(List<T> items, int totalItems)
        {
            Items = items;
            TotalItems = totalItems;
        }
    }
}
