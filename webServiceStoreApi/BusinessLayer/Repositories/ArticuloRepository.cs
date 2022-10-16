using BusinessLayer.Interfaces;
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
    public class ArticuloRepository : IArticulo
    {
        private ItemRepository _item;
        public ArticuloRepository(ItemRepository item)
        {
            _item = item;
        }

        public Articulo Add(Articulo articulo)
        {
            articulo.Cancelado = false;
            return ConvertItemToArticulo(_item.Add(ConvertArticuloToItem(articulo)));
        }

        public bool Cancel(string codigo)
        {
            return _item.Cancel(codigo);
        }

        public Articulo Find(string codigo)
        {
            return ConvertItemToArticulo(_item.Find(codigo));
        }

        public ICollection<Articulo> GetAll()
        {

            return _item.GetAll().Select(item =>
            {
                Articulo articulo = ConvertItemToArticulo(item);
                return articulo;
            }).ToList();
        }

        public bool Update(Articulo articulo)
        {
            return _item.Update(ConvertArticuloToItem(articulo));
        }

    
    }
}
