using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogueEntities;

namespace CatalogueModel
{
    public class CatalogueModel : ICatalogueModel
    {
        private List<Book> itemTable;
        private Dictionary<int, List<long>> categoryToItemId;
        private Dictionary<string, List<long>> authorNameToItemId;

        private long nextItemId = 1;

        public CatalogueModel() {
            itemTable = new List<Book>();
            categoryToItemId = new Dictionary<int, List<long>>();
            authorNameToItemId = new Dictionary<string, List<long>>();
        }

        public bool AddItem(Book item)
        {
            item.setItemId(nextItemId++);
            try {
                // start transaction

                itemTable.Add(item);

                int categoryId = item.getCategoryId();
                if (!categoryToItemId.ContainsKey(categoryId))
                {
                    categoryToItemId[categoryId] = new List<long>();
                }
                categoryToItemId[categoryId].Add(item.getItemId());

                string authName = item.getAuthorName().ToLower();
                if (!authorNameToItemId.ContainsKey(authName)) {
                    authorNameToItemId[authName] = new List<long>();
                }
                authorNameToItemId[authName].Add(item.getItemId());

                // end transaction
                return true;
            }
            catch(Exception ex){
                // logging
                return false;
            }
        }

        public Book[] GetMostSoldItems(string key, int limit)
        {
            List<long> itemIds = new List<long>();

            try {
                int categoryId = (int)Enum.Parse(typeof(Category), key); // TODO catch exception

                if (categoryToItemId.ContainsKey(categoryId))
                {
                    itemIds.AddRange(categoryToItemId[categoryId]);
                }
            }
            catch (Exception ex)
            {
                // suppress for now
            }

            if (authorNameToItemId.ContainsKey(key.ToLower()))
            {
                itemIds.AddRange(authorNameToItemId[key.ToLower()]);
            }

            itemIds = itemIds.Distinct<long>().ToList();

            List<Book> filteredItems = new List<Book>();

            itemIds.ForEach(itemId => {
                filteredItems.Add(itemTable.First(itemFromTable => itemFromTable.getItemId() == itemId));
            });

            filteredItems.Sort(delegate(Book item1, Book item2)
            { 
                return (int)(item2.getSoldCount() - item1.getSoldCount());
            });

            return filteredItems.Count > limit ? filteredItems.GetRange(0, limit).ToArray() : filteredItems.ToArray();
        }
    }
}
