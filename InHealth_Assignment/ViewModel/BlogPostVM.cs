using SGHBillingCodesApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InHealth_Assignment.Web.ViewModel
{
    public class BlogPostVM
    {
        public long blogPostId { get; set; }
        public string Title { get; set; }
        public string PostContent { get; set; }
        public string Author { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class BlogPostDetailsVM
    {
        public List<BlogPostVM> BlogPostList { get; set; }
        public int TotalCount { get; set; }
    }

    public class BlogPostSearchVM
    {
        public PaginationRequest PaginationRequest { get; set; }

        public BlogPostVM blogPostVM { get; set; }
    }

}