using InHealth_Assignment.Business;
using InHealth_Assignment.Web.Authentication;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InHealth_Assignment.Web.Authorization
{
    public class CustomAuthorizeAttribute:AuthorizeAttribute
    {
        #region "Member Declaration"
        public readonly GenericService _genericService = new GenericService();
        #endregion

        protected virtual MyPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as MyPrincipal; }
        }
        
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                var authorizedRoles = _genericService.UserRegistration.GetAll().Where(x => x.emailId.Equals(CurrentUser.Identity.Name)).FirstOrDefault().UserRole.RoleName;

                Roles = String.IsNullOrEmpty(Roles) ? authorizedRoles : Roles;
                
                if (!String.IsNullOrEmpty(Roles))
                {
                    if (!Roles.Contains(authorizedRoles))
                    {
                        filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new { controller = "Home", action = "AccessDenied" }));
                    }
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                RouteValueDictionary(new { controller = "Home", action = "AccessDenied" }));
            }

        }
    }
}