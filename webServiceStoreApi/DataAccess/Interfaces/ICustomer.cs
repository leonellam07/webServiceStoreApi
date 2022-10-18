using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICustomer
    {
        public Customer Find(int id);
        public Customer Find(string name);
        public ICollection<Customer> GetAll();
        public Customer Add(Customer customer);
        public bool Update(Customer customer);

    }
}
