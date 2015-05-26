
namespace PsychologyVisitSite.Domain.Concrete
{
    using System.Web.Security;

    using PsychologyVisitSite.Domain.Abstract;

    public class FormAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }

            return result;
        }
    }
}
