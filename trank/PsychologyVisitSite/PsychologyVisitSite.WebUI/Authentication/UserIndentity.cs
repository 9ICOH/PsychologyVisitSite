
namespace PsychologyVisitSite.WebUI.Authentication
{
    using System;
    using System.Linq;
    using System.Security.Principal;

    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Entities;
    using System.Collections.Generic;

    public class UserIndentity : IIdentity, IUserProvider
    {
        private IEnumerable<UserRole> userRoles;

        public User User { get; set; }

        public string AuthenticationType
        {
            get
            {
                return typeof(User).ToString();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return User != null;
            }
        }

        public bool InRoles(string roles)
        {
            if (string.IsNullOrWhiteSpace(roles))
            {
                return false;
            }

            var rolesArray = roles.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var role in rolesArray)
            {
                var hasRole = this.userRoles.Any(p => string.Compare(p.Role.Code, role, true) == 0);
                if (hasRole)
                {
                    return true;
                }
            }
            return false;

        }

        public string Name
        {
            get
            {
                if (User != null)
                {
                    return User.Email;
                }
                //иначе аноним
                return "anonym";
            }
        }

        public void Init(string email, IUsersRepository userRepository, IUserRoleRepository userRoleRepository)
        {
            if (!string.IsNullOrEmpty(email))
            {
                User = userRepository.GetUser(email);
                this.userRoles = userRoleRepository.FindAll(p => p.UserID == User.ID).ToList();
            }
        }
    }
}