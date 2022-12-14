using BusinessLayer.Interfaces;
using BusinessLayer.Utilities;
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
    public class IClienteRepository : ICliente
    {
        private readonly ICustomerRepository _customer;
        public IClienteRepository(ApplicationContext db) => _customer = new ICustomerRepository(db);


        public Cliente Add(Cliente cliente)
        {
            return MapObjects.ConvertCustomerToCliente(_customer.Add(MapObjects.ConvertClienteToCustomer(cliente)));
        }


        public Cliente Find(int id)
        {
            return MapObjects.ConvertCustomerToCliente(_customer.Find(id));
        }

        public Cliente Find(string nit)
        {
            return MapObjects.ConvertCustomerToCliente(_customer.Find(nit));
        }

        public ICollection<Cliente> GetAll()
        {
            return _customer.GetAll().Select(customer =>
            {
                Cliente cliente = MapObjects.ConvertCustomerToCliente(customer);
                return cliente;
            }).ToList();
        }

        public bool Update(Cliente cliente)
        {
            return _customer.Update(MapObjects.ConvertClienteToCustomer(cliente));
        }

      
    }
}
