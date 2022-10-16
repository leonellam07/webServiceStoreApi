using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IFactura
    {
        public Factura Find(int id);
        public ICollection<Factura> GetAll(DateTime date);
        public ICollection<Factura> GetAll(int year, int month, bool? canceled);
        public Factura Add(Factura factura);
        public bool Cancel(int id);
    }
}
