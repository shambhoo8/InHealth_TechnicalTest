using InHealth_Assignment.Data.Contract;
using InHealth_Assignment.Model.Entities;
using System;

namespace InHealth_Assignment.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commits the unit of work
        /// </summary>
        void Commit();

        IRepository<UserRole> UserRole { get; }
        IRepository<UserRegistration> UserRegistration { get; }
        IRepository<BlogPost> BlogPost { get; }
        IRepository<BlogPostComments> BlogPostComments { get; }

    }
}
