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
    public class UserRegistrationController : ApiController
    {
        [Route("~/Api/UserRegistration/RegisterNewUserService")]
        [HttpPost]
        public ReturnResult RegisterNewUser([FromBody] UserRegistrationVM _userRegistration)
        {
            UserRegistrationHelper _UserRegistrationHelper = new UserRegistrationHelper();
            return _UserRegistrationHelper.SaveUserRegistrationData(_userRegistration);
        }
    }
}
