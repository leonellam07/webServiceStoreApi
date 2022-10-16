using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IArticulo
    {
        public Articulo Add(Articulo articulo);
        public Articulo Find(string codigo);
        public ICollection<Articulo> GetAll();
        public bool Update(Articulo articulo);
        public bool Cancel(string code);
    }
}
