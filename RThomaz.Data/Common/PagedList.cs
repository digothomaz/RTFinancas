using System;
using System.Collections.Generic;
using System.Linq;

namespace RThomaz.Data.Common
{
    public class PagedList<T>
    {
        private readonly int _queryCount;
        private readonly IEnumerable<T> _entities;
        private readonly int _pageNumber;
        private readonly int _pageSize;

        public PagedList(IQueryable<T> query, int pageNumber, int pageSize)
        {
            _pageNumber = pageNumber;
            _pageSize = pageSize;
            _queryCount = query.Count();
            _entities = query.Skip((pageNumber -1) * pageSize).Take(pageSize).ToList();
        }
                
        public int PageSize 
        {
            get
            {
                return _pageSize;
            }
        }

        public int PageNumber
        {
            get
            {
                return _pageNumber;
            }
        }
        
        public IEnumerable<T> Entities
        {
            get
            {
                return _entities;
            }
        }

        public int QueryCount 
        {
            get
            {
                return _queryCount;
            }
        }

        public bool IsFirstPage
        {
            get
            {
                return (PageNumber == 1);
            }
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }

        public bool HasNextPage 
        {
            get
            {
                return (PageNumber < PageCount);
            }
        }

        public bool IsLastPage
        {
            get
            {
                return (PageNumber == PageCount);
            }
        }

        public int PageCount 
        {
            get
            {
                return (int)Math.Ceiling(_queryCount / (double)PageSize); 
            }
        }
    }
}
