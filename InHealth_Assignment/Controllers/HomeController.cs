using InHealth_Assignment.Business;
using InHealth_Assignment.Web.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InHealth_Assignment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        public ActionResult Login()
        {
            //string returnURL = string.Empty;
            //if (HttpContext.Request.IsAuthenticated)
            //{
            //    var role = new GenericService().UserRegistration.GetAll().Where(x => x.emailId.Equals(HttpContext.User.Identity.Name)).FirstOrDefault().UserRole.RoleName;
            //    if (role.ToLower().Equals("admin"))
            //    {
            //        returnURL = "~/Views/Home/_PartialBlogPostList.cshtml";
            //    }
            //    else
            //    {
            //        returnURL = "~/Views/Home/_PartialBlogPostUser.cshtml";
            //    }
            //}
            //else
            //{
            //    returnURL = "~/Views/Home/_PartialLogin.cshtml";
            //}

            return View("~/Views/Home/_PartialLogin.cshtml");
        }

        public ActionResult UserRegistration()
        {
            DefaultSignOut();
            return View("~/Views/Home/_PartialUserRegistration.cshtml");
        }

        public ActionResult BlogPost()
        {
            DefaultSignOut();
            return View("~/Views/Home/_PartialBlogPost.cshtml");
        }
        public ActionResult PostDetail()
        {
            return View("~/Views/Home/_PartialPostDetail.cshtml");
        }
        [CustomAuthorize(Roles = "Standard User")]
        public ActionResult BlogPostUser()
        {
            return View("~/Views/Home/_PartialBlogPostUser.cshtml");
        }
        [CustomAuthorize(Roles = "Standard User")]
        public ActionResult NewPost()
        {
            return View("~/Views/Home/_PartialNewPost.cshtml");
        }
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult NewPostAdmin()
        {
            return View("~/Views/Home/_PartialNewPostAdmin.cshtml");
        }
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult BlogPostList()
        {
            return View("~/Views/Home/_PartialBlogPostList.cshtml");
        }
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult UserList()
        {
            return View("~/Views/Home/_PartialUserList.cshtml");
        }
        public ActionResult AccessDenied()
        {
            string returnURL = string.Empty;
            if(HttpContext.Request.IsAuthenticated)
            {
                var role=new GenericService().UserRegistration.GetAll().Where(x => x.emailId.Equals(HttpContext.User.Identity.Name)).FirstOrDefault().UserRole.RoleName;

                if(role.ToLower().Equals("admin"))
                {
                    returnURL = "~/Views/Home/AccessDeniedAdmin.cshtml";
                }
                else
                {
                    returnURL = "~/Views/Home/AccessDeniedUser.cshtml";
                }
            }
            else
            {
                returnURL = "~/Views/Home/AccessDenied.cshtml";
            }
           
            ViewBag.Message = "You don't have permission to access this page!!!";

            return View(returnURL);
        }
        public ActionResult LogOut()
        {
            DefaultSignOut();

            return View("~/Views/Home/_PartialLogin.cshtml");
        }

        public void DefaultSignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            // clear authentication cookie
            HttpCookie authoCookies = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            authoCookies.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(authoCookies);
        }
    }
}