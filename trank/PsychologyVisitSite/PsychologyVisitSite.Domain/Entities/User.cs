
namespace PsychologyVisitSite.Domain.Entities
{
    using System;

    public class User
    {

        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ActivatedDate { get; set; }
        public string ActivatedLink { get; set; }
        public DateTime LastVisitDate { get; set; }
        public string AvatarPath { get; set; }
        public UserRole UserRoles { get; set; }

        public static string GetActivateUrl()
        {
            return Guid.NewGuid().ToString("N");
        }

        public string ConfirmPassword { get; set; }

        public string Captcha { get; set; }

        public bool InRoles(string roles)
        {
            if (string.IsNullOrWhiteSpace(roles))
            {
                return false;
            }

            var rolesArray = roles.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var role in rolesArray)
            {
                //todo repository
               // var hasRole = UserRoles.Any(p => string.Compare(p.Role.Code, role, true) == 0);
              //  if (hasRole)
                {
                    return true;
                }
            }
            return false;
        }
    }
}