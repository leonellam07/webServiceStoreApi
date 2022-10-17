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
    public class ArticuloRepository : IArticulo
    {
        private readonly IItemRepository _item;
        public ArticuloRepository(ApplicationContext db) => _item = new IItemRepository(db);

        public Articulo Add(Articulo articulo)
        {
            articulo.Cancelado = false;
            return MapObjects.ConvertItemToArticulo(_item.Add(MapObjects.ConvertArticuloToItem(articulo)));
        }

        public bool Cancel(string codigo)
        {
            return _item.Cancel(codigo);
        }

        public Articulo Find(string codigo)
        {
            return MapObjects.ConvertItemToArticulo(_item.Find(codigo));
        }

        public ICollection<Articulo> GetAll()
        {

            return _item.GetAll().Select(item =>
            {
                Articulo articulo = MapObjects.ConvertItemToArticulo(item);
                return articulo;
            }).ToList();
        }

        public bool Update(Articulo articulo)
        {
            return _item.Update(MapObjects.ConvertArticuloToItem(articulo));
        }

    
    }
}
