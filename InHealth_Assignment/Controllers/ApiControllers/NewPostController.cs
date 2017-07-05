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
    public class NewPostController : ApiController
    {
        [Route("~/Api/NewPost/AddNewPostService")]
        [HttpPost]
        public ReturnResult SaveNewPostData(BlogPostVM _blogPostVM)
        {
            BlogPostHelper _blogPostHelper = new BlogPostHelper();
            return _blogPostHelper.SaveNewPostData(_blogPostVM);
        }
    }
}
