using InHealth_Assignment.Web.Helpers;
using InHealth_Assignment.Web.Token;
using InHealth_Assignment.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InHealth_Assignment.Web.Controllers.ApiControllers
{
    //[AuthorizeAPI]
    public class LoginController : ApiController
    {
        [Route("~/Api/Login/ValidateUserService")]
        [HttpPut]
        public LoginVM ValidateUserCredentials([FromBody] LoginVM _loginVM)
        {
            LoginHelper _loginHelper = new LoginHelper();
            return _loginHelper.ValidateUserCredentials(_loginVM);
        }
    }
}
