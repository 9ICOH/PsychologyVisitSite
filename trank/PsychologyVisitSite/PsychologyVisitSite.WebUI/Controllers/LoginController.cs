
namespace PsychologyVisitSite.WebUI.Controllers
{
    using System.Web.Http;

    using PsychologyVisitSite.WebUI.Authentication;

    public class LoginController : ApiController
    {
        private readonly IAuthentication auth;


        public LoginController(IAuthentication auth)
        {
            this.auth = auth;
        }

        public void Login(string email, string password, bool isPersistent)
        { 
             var user = this.auth.Login(email, password, isPersistent);
            if (user != null)
            {

            }

        }

        public void Logout()
        {
            this.auth.LogOut();
        }
    }
}
