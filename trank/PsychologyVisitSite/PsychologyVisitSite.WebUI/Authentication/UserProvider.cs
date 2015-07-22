
namespace PsychologyVisitSite.WebUI.Authentication
{
    using System.Security.Principal;

    using PsychologyVisitSite.Domain.Abstract;

    public class UserProvider : IPrincipal
    {
        private UserIndentity userIdentity;

        public UserProvider(string name, IUsersRepository userRepository, IUserRoleRepository userRoleRepository)
        {
            userIdentity = new UserIndentity();
            userIdentity.Init(name, userRepository, userRoleRepository);
        }

        public override string ToString()
        {
            return userIdentity.Name;
        }

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
            return userIdentity.InRoles(role);
        }

        #endregion
    }
}