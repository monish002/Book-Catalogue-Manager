using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogueEntities;

namespace CatalogueModel
{
    public interface ICatalogueModel
    {
        bool AddItem(Book item);

        Book[] GetMostSoldItems(string key, int limit);
    }
}
