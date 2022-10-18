using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ICliente
    {
        public Cliente Add(Cliente cliente);
        public Cliente Find(int id);
        public Cliente Find(string name);
        public ICollection<Cliente> GetAll();
        public bool Update(Cliente cliente);
    }
}
