using InHealth_Assignment.Business;
using InHealth_Assignment.Model.Entities;
using InHealth_Assignment.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InHealth_Assignment.Web.Helpers
{
    public class BlogPostHelper
    {
        #region "Member Declaration"
        public readonly GenericService _genericService = null;
        #endregion

        #region "Constructor"
        public BlogPostHelper()
        {
            _genericService = new GenericService();
        }
        #endregion

        #region "Public Methods"
        public ReturnResult SaveNewPostData(BlogPostVM blogPostVM)
        {
            ReturnResult returnResult = new ReturnResult();
            try
            {
                var userData = _genericService.UserRegistration.GetAll().Where(x => x.emailId.Equals(HttpContext.Current.User.Identity.Name)).FirstOrDefault();
                BlogPost _newBlogPost = new BlogPost();
                _newBlogPost.CreatedBy = userData.Id;
                _newBlogPost.Title = blogPostVM.Title;
                _newBlogPost.PostContent = blogPostVM.PostContent;
                _newBlogPost.CreatedDate = DateTime.Now;
                _newBlogPost.IsActive = true;

                _genericService.BlogPost.Insert(_newBlogPost);
                _genericService.Commit();

                if(_newBlogPost==null)
                {
                    returnResult.Success = false;
                    returnResult.Message = "Error occured!!!";
                }
                else
                {
                    if(userData.UserRole.RoleName.Equals("Admin"))
                        returnResult.RedirectURL = "/BlogPostList";
                   else
                        returnResult.RedirectURL = "/BlogPostUser";

                    returnResult.Success = true;
                    returnResult.Message = "Data saved successfully!!!";
                    returnResult.BlogPostId = _newBlogPost.Id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return returnResult;
        }
        public BlogPostDetailsVM GetAllPost()
        {
            BlogPostDetailsVM _blogPostDetailsVM = new BlogPostDetailsVM();

            IQueryable<BlogPostVM> _blogPostVMList;

            _blogPostVMList = _genericService.BlogPost.GetAll().Where(x => (x.IsActive == true && x.UserRegistration.IsActive==true)).
                            Select(x => new BlogPostVM
                            {
                                blogPostId = x.Id,
                                Title = x.Title,
                                PostContent = x.PostContent,
                                CreatedBy = x.CreatedBy,
                                CreatedDate = x.CreatedDate,
                                Author = x.UserRegistration.fName + " " + x.UserRegistration.lName
                            }).OrderByDescending(y=> y.CreatedDate);
           
            _blogPostDetailsVM.BlogPostList = _blogPostVMList.ToList();
            _blogPostDetailsVM.TotalCount = _blogPostVMList.Count();

            return _blogPostDetailsVM;
        }
        public BlogPostDetailsVM GetAllPostByUser()
        {
            BlogPostDetailsVM _blogPostDetailsVM = new BlogPostDetailsVM();
            try
            { 
                var userId = HttpContext.Current.User.Identity.Name;
                var _createdBy = _genericService.UserRegistration.GetAll().Where(x => x.emailId.Equals(userId)).FirstOrDefault().Id;
                IQueryable<BlogPostVM> _blogPostVMList;

                _blogPostVMList = _genericService.BlogPost.GetAll().Where(x => x.IsActive == true && (x.UserRegistration.IsActive == true && x.CreatedBy == _createdBy)).
                                Select(x => new BlogPostVM
                                {
                                    blogPostId = x.Id,
                                    Title = x.Title,
                                    PostContent = x.PostContent,
                                    CreatedBy = x.CreatedBy,
                                    CreatedDate = x.CreatedDate,
                                    Author = x.UserRegistration.fName + " " + x.UserRegistration.lName
                                });

                _blogPostDetailsVM.BlogPostList = _blogPostVMList.ToList();
                _blogPostDetailsVM.TotalCount = _blogPostVMList.Count();
            }
            catch(Exception ex)
            { throw new Exception(ex.Message); }

            return _blogPostDetailsVM;
        }
        public BlogPostVM GetPostbyId(long _postId)
        {
            BlogPostVM _blogPostVM = new BlogPostVM();

            var postData = _genericService.BlogPost.GetAll().Where(x => x.Id == _postId).Select(x => new BlogPostVM
            {
                blogPostId = x.Id,
                Title = x.Title,
                PostContent = x.PostContent,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                Author=x.UserRegistration.fName+" "+x.UserRegistration.lName
            }).ToList();

            if (postData.Any())
            {
                _blogPostVM = postData.FirstOrDefault();
            }
            return _blogPostVM;
        }
        public ReturnResult AddNewComment(BlogPostCommentsVM _blogPostCommentsVM)
        {
            ReturnResult _returnResult = new ReturnResult();
            try
            {
                BlogPostComments _blogPostComments = new BlogPostComments();
                _blogPostComments.blogPostId = _blogPostCommentsVM.blogPostId;
                _blogPostComments.commentContent = _blogPostCommentsVM.commentContent;
                _blogPostComments.CommentDate = DateTime.UtcNow;
                _blogPostComments.IsActive = true;

                _genericService.BlogPostComments.Insert(_blogPostComments);
                _genericService.Commit();

                if(_blogPostComments==null)
                {
                    _returnResult.Success = false;
                }
                else
                {
                    _returnResult.Success = true;
                    _returnResult.Message = "Comment posted successfully!!!";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return _returnResult;
        }
        public PostCommentsVM GetCommentsByPostId(long _postId)
        {
            PostCommentsVM _PostCommentsVM = new PostCommentsVM();
            
            List<BlogPostComments> _blogPostCommentsList = new List<BlogPostComments>();

            try
            {
                var commentsData = _genericService.BlogPostComments.GetAll().Where(x => (x.IsActive == true && x.blogPostId == _postId)).ToList();

                if (commentsData.Any())
                {
                    _PostCommentsVM.CommentList = commentsData.Select(x => new BlogPostCommentsVM
                    {
                        blogPostId = x.blogPostId,
                        blogPostCommentId = x.blogPostCommentId,
                        commentContent = x.commentContent,
                        CommentDate = x.CommentDate,
                        IsActive = x.IsActive
                    }).ToList();
                    _PostCommentsVM.TotalCount = commentsData.Count();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
           
            return _PostCommentsVM;
        }

        public ReturnResult DeletePost(BlogPostVM _blogPostVM)
        {
            ReturnResult _ReturnResult = new ReturnResult();

            var blogPostData = _genericService.BlogPost.GetAll().Where(x => x.Id == _blogPostVM.blogPostId).FirstOrDefault();

            blogPostData.IsActive = false;
            _genericService.BlogPost.Update(blogPostData);
            _genericService.Commit();

            if(blogPostData==null)
            {
                _ReturnResult.Success = false;
                _ReturnResult.Message = "Error occured!!!";
            }
            else
            {
                _ReturnResult.Success = true;
                _ReturnResult.Message = "Post deleted successfully!!!";
            }

            return _ReturnResult;
        }
        #endregion

        #region "Private Methods"

        #endregion

    }
}