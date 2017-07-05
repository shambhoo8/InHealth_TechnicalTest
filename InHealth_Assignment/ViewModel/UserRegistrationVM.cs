using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InHealth_Assignment.Web.ViewModel
{
    public class UserRegistrationVM
    {
        public long userId { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
    public class ReturnResult
    {
        public long UserId { get; set; }
        public long BlogPostId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string RedirectURL { get; set; }
    }

    public class UserRegistrationListVM
    {
        public List<UserRegistrationVM> userRegistrationList { get; set; }
        public int TotalCount { get; set; }
    }
}