using System.Web;
using System.Web.Mvc;

namespace RThomaz.Web.Common
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.User.Identity.IsAuthenticated;
        }
    }
}