using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs
{
    public class DTOPaginado<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int TotalItems { get; set; }

        public DTOPaginado()
        {
            
        }
    }
}
