using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogueModel;
using CatalogueEntities;

namespace CatalogueManagement
{
    public interface ICatalogueManager
    {
        bool AddAnItem(Book item);

        Book[] SearchItems(string key);

        Book[] GetMostSoldItems(string key, int limit);
    }
}
