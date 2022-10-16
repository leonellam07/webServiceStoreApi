using BusinessLayer.Interfaces;
using DataAccess.Interfaces;
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

        private IInvoice _invoice;
        public FacturaRepository(IInvoice invoice)
        {
            _invoice = invoice;
        }


        public Factura Add(Factura factura)
        {
            return ConvertInvoiceToFactura(_invoice.Add(ConvertFacturaToInvoice(factura)));
        }

        public bool Cancel(int id)
        {
            return _invoice.Cancel(id);
        }

        public Factura Find(int id)
        {
            return ConvertInvoiceToFactura(_invoice.Find(id));
        }

        public ICollection<Factura> GetAll(DateTime fecha)
        {
            return _invoice.GetAll(fecha).Select(invoice =>
            {
                return ConvertInvoiceToFactura(invoice); 
            }).ToList();
        }

        public ICollection<Factura> GetAll(int anio, int mes, bool? cancelado)
        {
            return _invoice.GetAll(anio, mes, cancelado).Select(invoice =>
            {
                return ConvertInvoiceToFactura(invoice);
            }).ToList();
        }


      
    }
}
