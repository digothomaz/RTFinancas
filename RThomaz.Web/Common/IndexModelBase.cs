using System.Configuration;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Web.Mvc;
using RThomaz.Data.Common;

namespace RThomaz.Web.Common
{
    public abstract class IndexModelBase<TEntity> : ModelBase
        where TEntity : EntityObject
    {
        private readonly PagedList<TEntity> _pagedList;
        private readonly SelectList _itemsPerPage;

        public IndexModelBase(string title, string controllerName, PagedList<TEntity> pagedList)
            : base(title, controllerName)
        {
            _pagedList = pagedList;
            var items = from x in ConfigurationManager.AppSettings["ItemsPerPage"].Split(';') select int.Parse(x.Trim());
            _itemsPerPage = new SelectList(items, pagedList.PageSize);
        }

        public PagedList<TEntity> PagedList
        {
            get
            {
                return _pagedList;
            }
        }

        public SelectList ItemsPerPage
        {
            get
            {
                return _itemsPerPage;
            }
        }
    }
}