using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InHealth_Assignment.Web.ViewModel
{
    public class BlogPostCommentsVM
    {
        public long blogPostCommentId { get; set; }
        public long blogPostId { get; set; }
        public string commentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class PostCommentsVM
    {
        public List<BlogPostCommentsVM> CommentList { get; set; }
        public int TotalCount { get; set; }
    }
}