using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogueModel;
using CatalogueEntities;

namespace CatalogueManagement
{
    public class CatalogueManager : ICatalogueManager
    {
        private ICatalogueModel _model;

        public CatalogueManager(ICatalogueModel model) {
            _model = model;
        }

        public bool AddAnItem(Book item)
        {
            Book catalogueItem = item as Book;
            return _model.AddItem(catalogueItem);
        }

        /// <summary>
        /// Finds all items for which title or author name starts with key.
        /// </summary>
        /// <param name="key"></param>
        public Book[] SearchItems(string key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds all items that has exact match of 'key' with category name or with author name
        /// </summary>
        /// <param name="key"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Book[] GetMostSoldItems(string key, int limit)
        {
            return _model.GetMostSoldItems(key, limit);
        }
    }
}
