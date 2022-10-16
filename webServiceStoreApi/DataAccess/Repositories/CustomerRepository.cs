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
    public class CustomerRepository : ICustomer
    {
        private ApplicationContext _db;

        public CustomerRepository(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }

        public Customer Add(Customer customer)
        {
            _db.Add(customer);
            _db.SaveChanges();
            return customer;
        }

        public Customer Find(int id)
        {
            if (!_db.Customers.Any(w => w.Id == id)) throw new Exception("Cliente no encontrado");
            return _db.Customers.Where(w => w.Id == id).FirstOrDefault();
        }

        public Customer Find(string nit)
        {
            if (!_db.Customers.Any(w => w.NIT == nit)) throw new Exception("Cliente no encontrado");
            return _db.Customers.Where(w => w.NIT == nit).FirstOrDefault();
        }

        public ICollection<Customer> GetAll()
        {
            if (!_db.Customers.Any()) throw new Exception("No hay clientes disponibles");
            return _db.Customers.ToList();
        }

        public bool Update(Customer customer)
        {
            if (!_db.Customers.Any(w => w.Id == customer.Id)) throw new Exception("Cliente no encontrado");
            _db.Update(customer);
            _db.SaveChanges();
            return true;
        }
    }
}
