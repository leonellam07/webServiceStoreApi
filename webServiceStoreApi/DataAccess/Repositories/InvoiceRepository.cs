using DataAccess.Interfaces;
using DataBase;
using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class IInvoiceRepository : IInvoice
    {
        private readonly ApplicationContext _db;


        public IInvoiceRepository(ApplicationContext db)
        {
            _db = db;
        }

        public Invoice Add(Invoice invoice)
        {
            _db.Add(invoice);
            _db.SaveChanges();
            return invoice;
        }

        public bool Cancel(int id)
        {
            if (!_db.Invoices.Any(w => w.Id == id)) throw new Exception("Factura no encontrada");
            Invoice invoice = _db.Invoices.Where(w => w.Id == id).FirstOrDefault();
            invoice.IsCanceled = true;
            _db.Invoices.Update(invoice);
            _db.SaveChanges();
            return true;
        }

        public Invoice Find(int id)
        {
            if (!_db.Invoices.Any(w => w.Id == id)) throw new Exception("Factura no encontrada");
            return _db.Invoices.Where(w => w.Id == id).FirstOrDefault();
        }

        public ICollection<Invoice> GetAll(DateTime date)
        {
            if (!_db.Invoices.Any(w => w.Created.ToString("yyyyMMdd") == date.ToString("yyyyMMdd"))) throw new Exception("Facturas no encontradas");
            return _db.Invoices.Where(w => w.Created.ToString("yyyyMMdd") == date.ToString("yyyyMMdd")).ToList();
        }

        public ICollection<Invoice> GetAll(int year, int month, bool? canceled)
        {
            if (!_db.Invoices.Any(w => w.Created.Year == year && w.Created.Month == month)) throw new Exception("Facturas no encontradas");
            return _db.Invoices.Where(w => w.Created.Year == year && w.Created.Month == month).ToList();
        }
    }
}
