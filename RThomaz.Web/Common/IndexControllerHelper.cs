using System.Configuration;
using System.Web;

namespace RThomaz.Web.Common
{
    public static class IndexControllerHelper
    {
        #region Pagging Functions

        public static int GetPageNumber()
        {
            int pageNumber;
            if (!int.TryParse(HttpContext.Current.Request["currentPageNumber"], out pageNumber))
                pageNumber = 1;

            int pageSize;
            if (!int.TryParse(HttpContext.Current.Request["pageSize"], out pageSize))
                pageSize = int.Parse(ConfigurationManager.AppSettings["DefaultPageSize"]);

            int pageCount;
            if (!int.TryParse(HttpContext.Current.Request["pageCount"], out pageCount))
                pageCount = 1;

            if (!string.IsNullOrEmpty(HttpContext.Current.Request["MoveFirstPage"]))
            {
                pageNumber = 1;
            }
            else if (!string.IsNullOrEmpty(HttpContext.Current.Request["MovePreviousPage"]))
            {
                pageNumber--;
            }
            else if (!string.IsNullOrEmpty(HttpContext.Current.Request["MoveNextPage"]))
            {
                pageNumber++;
            }
            else if (!string.IsNullOrEmpty(HttpContext.Current.Request["MoveLastPage"]))
            {
                pageNumber = pageCount;
            }

            return pageNumber;
        }

        public static int GetPageSize()
        {
            int pageSize;
            if (!int.TryParse(HttpContext.Current.Request["pageSize"], out pageSize))
                pageSize = int.Parse(ConfigurationManager.AppSettings["DefaultPageSize"]);

            return pageSize;
        }

        #endregion       
    }
}