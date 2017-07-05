using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InHealth_Assignment.Web.ViewModel
{
    public class LoginVM
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public long UserId { get; set; }
        public string UserRole { get; set; }
        public string RedirectURL { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

    }
}