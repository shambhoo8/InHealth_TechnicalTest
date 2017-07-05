using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using InHealth_Assignment.Model.Entities;

namespace InHealth_Assignment.Data.DBContext
{
    public class InHealth_AssignmentContext : DbContext
    {
        public InHealth_AssignmentContext()
            : base("InHealth_AssignmentContext")
        {
            Database.SetInitializer<InHealth_AssignmentContext>(null);
        }

        #region "public table instances"
        public DbSet<UserRole> UserRoles { get; set; } 
        public DbSet<UserRegistration> UserRegistration { get; set; } 
        public DbSet<BlogPost> BlogPosts { get; set; } 
        public DbSet<BlogPostComments> BlogPostComments { get; set; }
        #endregion

    }
}
