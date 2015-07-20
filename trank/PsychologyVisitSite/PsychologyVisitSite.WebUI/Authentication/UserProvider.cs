
namespace PsychologyVisitSite.WebUI.Authentication
{
    using System.Security.Principal;

    using PsychologyVisitSite.Domain.Abstract;

    public class UserProvider : IPrincipal
    {
        private UserIndentity userIdentity;

        #region IPrincipal Members

        public IIdentity Identity
        {
            get
            {
                return userIdentity;
            }
        }

        public bool IsInRole(string role)
        {
            if (userIdentity.User == null)
            {
                return false;
            }
            return userIdentity.User.InRoles(role);
        }

        #endregion


        public UserProvider(string name, IAuthenticationRepository repository)
        {
            userIdentity = new UserIndentity();
            userIdentity.Init(name, repository);
        }


        public override string ToString()
        {
            return userIdentity.Name;
        }
    }
}