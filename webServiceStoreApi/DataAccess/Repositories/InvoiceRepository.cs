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
            invoice.Customer = null;
            List<InvoiceDetail> details = invoice.InvoiceDetails.Select(detail => new InvoiceDetail
            {
                InvoiceId = detail.InvoiceId,
                ItemId = detail.ItemId,
                Noline = detail.Noline,
                Price = detail.Price,
                Quantity = detail.Quantity,
                Vat = detail.Vat,
                Total = detail.Total
            }).ToList();

            invoice.InvoiceDetails = details;
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

        public bool DeleteLine(int invoiceId, int idLine)
        {
            if (!_db.InvoiceDetails.Any(w => w.InvoiceId == invoiceId && w.Noline == idLine)) throw new Exception("Detalle no encontrado");

            InvoiceDetail detail = _db.InvoiceDetails.Where(w => w.InvoiceId == invoiceId && w.Noline == idLine).FirstOrDefault();
            _db.InvoiceDetails.Remove(detail);
            _db.SaveChanges();
            return true;
        }

        public Invoice Find(int id)
        {
            if (!_db.Invoices.Any(w => w.Id == id)) throw new Exception("Factura no encontrada");
            Invoice invoice = _db.Invoices.Where(w => w.Id == id).FirstOrDefault();
            invoice.Id = invoice.Id;
            invoice.Created = invoice.Created;
            invoice.CustomerId = invoice.CustomerId;
            invoice.Customer = _db.Customers.Where(w => w.Id == invoice.CustomerId).FirstOrDefault();
            invoice.InvoiceDetails = _db.InvoiceDetails.Where(w => w.InvoiceId == invoice.Id).Select(sub => new InvoiceDetail
            {
                Noline = sub.Noline,
                InvoiceId = sub.InvoiceId,
                ItemId = sub.ItemId,
                Item = _db.Items.Where(w2 => w2.Id == sub.ItemId).FirstOrDefault(),
                Quantity = sub.Quantity,
                Price = sub.Price,
                Vat = sub.Vat,
                Total = sub.Total

            }).ToList();
            invoice.Vat = invoice.Vat;
            invoice.Total = invoice.Total;
            invoice.IsCanceled = invoice.IsCanceled;
            invoice.IsClosed = invoice.IsClosed;
            return invoice;
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

        public ICollection<Invoice> GetAll()
        {
            if (!_db.Invoices.Any()) throw new Exception("Facturas no encontradas");

            List<Invoice> list = _db.Invoices.Select(invoice => new Invoice
            {
                Id = invoice.Id,
                Created = invoice.Created,
                CustomerId = invoice.CustomerId,
                Customer = _db.Customers.Where(w => w.Id == invoice.CustomerId).FirstOrDefault(),
                InvoiceDetails = _db.InvoiceDetails.Where(w => w.InvoiceId == invoice.Id).Select(sub => new InvoiceDetail
                {
                    Noline = sub.Noline,
                    InvoiceId = sub.InvoiceId,
                    ItemId = sub.ItemId,
                    Item = _db.Items.Where(w2 => w2.Id == sub.ItemId).FirstOrDefault(),
                    Quantity = sub.Quantity,
                    Price = sub.Price,
                    Vat = sub.Vat,
                    Total = sub.Total

                }).ToList(),
                Vat = invoice.Vat,
                Total = invoice.Total,
                IsCanceled = invoice.IsCanceled,
                IsClosed = invoice.IsClosed
            }).ToList();


            return list;
        }

        public bool Update(Invoice invoice)
        {
            if (!_db.Invoices.Any(w => w.Id == invoice.Id)) throw new Exception("Factura no encontrada");

            _db.Invoices.Update(invoice);
            _db.SaveChanges();
            return true;
        }
    }
}
