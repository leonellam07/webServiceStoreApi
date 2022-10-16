using DataBase.Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Utilities
{
    public static class ConvertObjects
    {
        #region Cliente-Customer
        public static Cliente ConvertCustomerToCliente(Customer customer)
        {
            return new Cliente
            {
                Id = customer.Id,
                PrimerNombre = customer.FirstName,
                SegundoNombre = customer.SecondName,
                Apellidos = customer.LastName,
                NIT = customer.NIT,
                Direccion = customer.Address,
                IdTipoCliente = customer.IdTypeCustomer
            };
        }

        public static Customer ConvertClienteToCustomer(Cliente cliente)
        {
            return new Customer
            {
                Id = cliente.Id,
                FirstName = cliente.PrimerNombre,
                SecondName = cliente.SegundoNombre,
                LastName = cliente.Apellidos,
                NIT = cliente.NIT,
                Address = cliente.Direccion,
                IdTypeCustomer = cliente.IdTipoCliente
            };
        }
        #endregion

        #region Articulo-Item
        public static Item ConvertArticuloToItem(Articulo articulo)
        {
            return new Item
            {
                Id = articulo.Id,
                Code = articulo.Codigo,
                Description = articulo.Descripcion,
                Cost = articulo.Costo,
                IsCanceled = articulo.Cancelado,
                Price = articulo.Precio,
                Quantity = articulo.Cantidad
            };
        }

        public static Articulo ConvertItemToArticulo(Item item)
        {
            return new Articulo
            {
                Id = item.Id,
                Codigo = item.Code,
                Descripcion = item.Description,
                Costo = item.Cost,
                Cancelado = item.IsCanceled,
                Precio = item.Price,
                Cantidad = item.Quantity
            };
        }
        #endregion

        #region Factura-Invoice
        public static Invoice ConvertFacturaToInvoice(Factura factura)
        {
            Invoice invoice = new Invoice
            {
                Id = factura.Id,
                Created = factura.FechaCreacion,
                CustomerId = factura.IdCliente,
                IsCanceled = factura.Cancelada,
                IsClosed = factura.Cerrada,
                Vat = factura.Impuesto,
                Total = factura.Total,
                Customer = ConvertClienteToCustomer(factura.Cliente)
            };
            invoice.InvoiceDetails = factura.FacturaDetalles.Select(detalle => ConvertFacturaDetalleToInvoiceDetail(detalle)).ToList();

            return invoice;
        }

        public static Factura ConvertInvoiceToFactura(Invoice invoice)
        {
            Factura factura = new Factura
            {
                Id = invoice.Id,
                FechaCreacion = invoice.Created,
                IdCliente = invoice.CustomerId,
                Cancelada = invoice.IsCanceled,
                Cerrada = invoice.IsClosed,
                Impuesto = invoice.Vat,
                Total = invoice.Total,
                Cliente = ConvertCustomerToCliente(invoice.Customer)
            };
            factura.FacturaDetalles = invoice.InvoiceDetails.Select(detail => ConvertInvoiceDetailToFacturaDetalle(detail)).ToList();

            return factura;
        }

        private static FacturaDetalle ConvertInvoiceDetailToFacturaDetalle(InvoiceDetail invoiceDetail)
        {
            return new FacturaDetalle
            {
                NoLinea = invoiceDetail.Noline,
                ArticuloId = invoiceDetail.InvoiceId,
                Articulo = ConvertItemToArticulo(invoiceDetail.Item),
                Cantidad = invoiceDetail.Quantity,
                Impuesto = invoiceDetail.Vat,
                Precio = invoiceDetail.Price,
                Total = invoiceDetail.Total
            };
        }

        private static InvoiceDetail ConvertFacturaDetalleToInvoiceDetail(FacturaDetalle facturaDetalle)
        {
            return new InvoiceDetail
            {
                Noline = facturaDetalle.NoLinea,
                ItemId = facturaDetalle.ArticuloId,
                Item = ConvertArticuloToItem(facturaDetalle.Articulo),
                Quantity = facturaDetalle.Cantidad,
                Vat = facturaDetalle.Impuesto,
                Price = facturaDetalle.Precio,
                Total = facturaDetalle.Total
            };
        }
        #endregion
    }
}
