
namespace PsychologyVisitSite.WebUI.Controllers
{
    using System.Web.Mvc;

    public class NavController : Controller
    {
        // GET: Nav
        public PartialViewResult Menu()
        {

            return PartialView("FlexMenu");
        }
    }
}