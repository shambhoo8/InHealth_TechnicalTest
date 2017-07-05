using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Http.Filters;

namespace InHealth_Assignment.Web.Token
{ 
    public class AuthorizeAPIAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var headers = actionContext.Request.Headers;
            var security = headers.Any(x => x.Key == "Security");
            if (security)
            {
                var value = headers.FirstOrDefault(x => x.Key == "Security").Value.FirstOrDefault();
                if (value != null)
                {
                    string token = value;
                    if (token == ConfigItems.APIToken)
                    {
                        return;
                    }
                }
            }

            actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            actionContext.Response.Content = new StringContent("Security Failed", Encoding.UTF8, "application/json");
            base.OnAuthorization(actionContext);
        }
    }

    public class ConfigItems
    {
        public static string APIToken
        {
            get
            {
                return WebConfigurationManager.AppSettings["APIToken"];
            }
        }
    }
}