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
    public class UserListController : ApiController
    {
        [Route("~/Api/UserList/GetUserListService")]
        [HttpGet]
        public UserRegistrationListVM GetUserList()
        {
            UserRegistrationHelper _userRegistrationHelper = new UserRegistrationHelper();
            return _userRegistrationHelper.GetRegisteredUserData();

        }

        [Route("~/Api/UserList/GetUserListService")]
        [HttpPost]
        public ReturnResult UpdateUserRole(UserRegistrationVM _userRegistrationVM)
        {
            UserRegistrationHelper _userRegistrationHelper = new UserRegistrationHelper();
            return _userRegistrationHelper.UpdateUserRole(_userRegistrationVM);
        }

        [Route("~/Api/UserList/GetUserListService")]
        [HttpPut]
        public ReturnResult DeleteUser(UserRegistrationVM _userRegistrationVM)
        {
            UserRegistrationHelper _userRegistrationHelper = new UserRegistrationHelper();
            return _userRegistrationHelper.DeleteUser(_userRegistrationVM);
        }
    }
}
