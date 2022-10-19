using BusinessLayer.Interfaces;
using BusinessLayer.Utilities;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using DataBase;
using DataBase.Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories
{
    public class FacturaRepository : IFactura
    {
        private readonly IInvoiceRepository _invoice;

        public FacturaRepository(ApplicationContext db) => _invoice = new IInvoiceRepository(db);

        public Factura Add(Factura factura)
        {
            return MapObjects.ConvertInvoiceToFactura(_invoice.Add(MapObjects.ConvertFacturaToInvoice(factura)));
        }

        public bool Cancel(int id)
        {
            return _invoice.Cancel(id);
        }

        public bool Delete(int id)
        {
            return _invoice.Delete(id);
        }

        public bool DeleteLine(int idFactura, int idLinea)
        {
            return _invoice.DeleteLine(idFactura, idLinea);
        }

        public Factura Find(int id)
        {
            return MapObjects.ConvertInvoiceToFactura(_invoice.Find(id));
        }

        public ICollection<Factura> GetAll(DateTime fecha)
        {
            return _invoice.GetAll(fecha).Select(invoice =>
            {
                return MapObjects.ConvertInvoiceToFactura(invoice); 
            }).ToList();
        }

        public ICollection<Factura> GetAll()
        {
            return _invoice.GetAll().Select(invoice =>
            {
                return MapObjects.ConvertInvoiceToFactura(invoice);
            }).ToList();
        }

        public ICollection<Factura> GetAll(int anio, int mes, bool? cancelado)
        {
            return _invoice.GetAll(anio, mes, cancelado).Select(invoice =>
            {
                return MapObjects.ConvertInvoiceToFactura(invoice);
            }).ToList();
        }

        public bool Update(Factura factura)
        {
            _invoice.Update(MapObjects.ConvertFacturaToInvoice(factura));
            return true;
        }
    }
}
