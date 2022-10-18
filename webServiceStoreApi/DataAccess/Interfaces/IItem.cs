using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IItem
    {
        public Item Add(Item item);
        public Item Find(string code);
        public ICollection<Item> GetAll();
        public bool Update(Item item);
        public bool Cancel(string code);
    }
}
