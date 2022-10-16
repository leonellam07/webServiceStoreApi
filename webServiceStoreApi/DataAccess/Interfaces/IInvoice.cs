using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IInvoice
    {
        public Invoice Find(int id);
        public ICollection<Invoice> GetAll(DateTime date);
        public ICollection<Invoice> GetAll(int year, int month, bool? canceled);
        public Invoice Add(Invoice invoice);
        public bool Cancel(int id);
    }
}
