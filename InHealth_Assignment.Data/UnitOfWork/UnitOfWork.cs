using InHealth_Assignment.Data.Context;
using InHealth_Assignment.Data.Contract;
using InHealth_Assignment.Data.DBContext;
using InHealth_Assignment.Model.Entities;
using System;
using System.Diagnostics;

namespace InHealth_Assignment.Data.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        #region Private member variables...
        protected InHealth_AssignmentContext _DataContext;
        private IRepository<UserRole> _userRole;
        private IRepository<UserRegistration> _userRegistration;
        private IRepository<BlogPost> _blogPost;
        private IRepository<BlogPostComments> _blogPostComments;

        #endregion

        #region Constructor

        public UnitOfWork()
        {
            _DataContext = new InHealth_AssignmentContext();
        }

        #endregion

        #region Public IRepository Creation properties...

        public IRepository<UserRole> UserRole
        {
            get
            {
                if (this._userRole == null)
                {
                    this._userRole = new Repository<UserRole>(_DataContext);
                }
                return _userRole;
            }
        }
        public IRepository<UserRegistration> UserRegistration
        {
            get
            {
                if (this._userRegistration == null)
                {
                    this._userRegistration = new Repository<UserRegistration>(_DataContext);
                }
                return _userRegistration;
            }
        }
        public IRepository<BlogPost> BlogPost
        {
            get
            {
                if (this._blogPost == null)
                {
                    this._blogPost = new Repository<BlogPost>(_DataContext);
                }
                return _blogPost;
            }
        }
        public IRepository<BlogPostComments> BlogPostComments
        {
            get
            {
                if (this._blogPostComments == null)
                {
                    this._blogPostComments = new Repository<BlogPostComments>(_DataContext);
                }
                return _blogPostComments;
            }
        }

        #endregion

        #region Public member methods...

        /// <summary>
        /// Commits the unit of work
        /// </summary>
        public void Commit()
        {
            _DataContext.SaveChanges();
        }
        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _DataContext.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}