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
    public class ItemRepository: IItem
    {
        private ApplicationContext _db;

        public ItemRepository(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }

        public Item Add(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();
            return item;
        }

        public bool Cancel(string code)
        {
            if (!_db.Items.Any(w => w.Code == code)) throw new Exception("Articulo no encontrado");
            Item item = _db.Items.Where(w => w.Code == code).FirstOrDefault();
            item.IsCanceled = true;
            _db.Items.Update(item);
            _db.SaveChanges();
            return true;
        }

        public Item Find(string code)
        {
            if (!_db.Items.Any(w => w.Code == code)) throw new Exception("Articulo no encontrado");
            return _db.Items.Where(w => w.Code == code).FirstOrDefault();
        }

        public ICollection<Item> GetAll()
        {
            if (!_db.Items.Any()) throw new Exception("No hay articulos disponibles");
            return _db.Items.Where(w => !w.IsCanceled).ToList();
        }

        public bool Update(Item item)
        {
            _db.Items.Update(item);
            _db.SaveChanges();
            return true;
        }
    }
}
