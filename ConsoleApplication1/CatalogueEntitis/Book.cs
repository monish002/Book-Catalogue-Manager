using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogueEntities
{
    public enum Category
    {
        SELF_HELP = 1,
        BIOGRAPHY
    }

    public class Book
    {
        protected string _title, _authorName;
        protected Category _categoryId;
        protected long _itemId, _soldCount;
        private string _publisher;
        private float _price;

        /// <summary>
        /// Constructor for Book entity
        /// </summary>
        public Book(
            string title,
            Category category,
            long soldCount,
            string authorName
            // TODO, other info
            )
        {
            this._title = title;
            this._categoryId = category;
            this._soldCount = soldCount;
            this._authorName = authorName;
        }

        public void setItemId(long itemId)
        {
            _itemId = itemId;
        }

        public long getItemId()
        {
            return _itemId;
        }

        public int getCategoryId()
        {
            return (int)this._categoryId;
        }

        public string getAuthorName()
        {
            return this._authorName;
        }

        public long getSoldCount()
        {
            return this._soldCount;
        }

        public string ToString()
        {
            return "    Title: " + _title + "\n\tSold count: " + _soldCount + "\n\tCategory: " + _categoryId.ToString();            
        }
    }
}
