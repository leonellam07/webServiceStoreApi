using BusinessLayer.Interfaces;
using BusinessLayer.Utilities;
using DataAccess.Repositories;
using DataBase.Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories
{
    public class ClienteRepository : ICliente
    {
        private CustomerRepository _customer;
        public ClienteRepository(CustomerRepository customer)
        {
            _customer = customer;
        }

        public Cliente Add(Cliente cliente)
        {
            return ConvertObjects.ConvertCustomerToCliente(_customer.Add(ConvertObjects.ConvertClienteToCustomer(cliente)));
        }


        public Cliente Find(int id)
        {
            return ConvertObjects.ConvertCustomerToCliente(_customer.Find(id));
        }

        public Cliente Find(string nit)
        {
            return ConvertObjects.ConvertCustomerToCliente(_customer.Find(nit));
        }

        public ICollection<Cliente> GetAll()
        {
            return _customer.GetAll().Select(customer =>
            {
                Cliente cliente = ConvertObjects.ConvertCustomerToCliente(customer);
                return cliente;
            }).ToList();
        }

        public bool Update(Cliente cliente)
        {
            return _customer.Update(ConvertObjects.ConvertClienteToCustomer(cliente));
        }

      
    }
}
