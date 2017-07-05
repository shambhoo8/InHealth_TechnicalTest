using InHealth_Assignment.Model.Entities;
using System.Security.Principal;

namespace InHealth_Assignment.Web.Authentication
{
    public class MyIdentity : IIdentity
    {
        public IIdentity Identity { get; set; }
        public UserRegistration User { get; set; }
        public MyIdentity(UserRegistration user)
        {
            Identity = new GenericIdentity(user.emailId);
            User = user;
        }
        public string AuthenticationType
        {
            get { return Identity.AuthenticationType; }
        }
        public bool IsAuthenticated
        {
            get { return Identity.IsAuthenticated; }
        }
        public string Name
        {
            get { return Identity.Name; }
        }
        public long Id
        {
            get { return User.Id; }
        }
        public string RoleName
        {
            get { return User.UserRole.RoleName; }
        }
    }
}