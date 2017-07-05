using InHealth_Assignment.Web.Helpers;
using InHealth_Assignment.Web.Token;
using InHealth_Assignment.Web.ViewModel;
using System.Web.Http;

namespace InHealth_Assignment.Web.Controllers.ApiControllers
{
    //[AuthorizeAPI]
    public class PostCommentsController : ApiController
    {
        [Route("~/Api/PostComments/SaveCommentService")]
        [HttpPost]
        public ReturnResult SaveComment([FromBody] BlogPostCommentsVM _blogPostCommentsVM)
        {
            BlogPostHelper _blogPostHelper = new BlogPostHelper();
            return _blogPostHelper.AddNewComment(_blogPostCommentsVM);
        }

        [Route("~/Api/PostComments/SaveCommentService")]
        [HttpPut]
        public PostCommentsVM GetCommentList([FromBody] BlogPostCommentsVM _blogPostCommentsVM)
        {
            BlogPostHelper _blogPostHelper = new BlogPostHelper();
            if(_blogPostCommentsVM!=null)
            {
                return _blogPostHelper.GetCommentsByPostId(_blogPostCommentsVM.blogPostId);
            }
           else
            {
                return new PostCommentsVM();
            }
        }
    }
}
